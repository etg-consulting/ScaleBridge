#region License
/* Copyright 2010, 2013 James F. Bellinger <http://www.zer7.com/software/hidsharp>

   Permission to use, copy, modify, and/or distribute this software for any
   purpose with or without fee is hereby granted, provided that the above
   copyright notice and this permission notice appear in all copies.

   THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
   WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
   MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR
   ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
   WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN
   ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF
   OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE. */
#endregion

using System;
using System.IO;
using System.Runtime.InteropServices;

namespace HidSharp.DeviceHelpers
{
    [ComVisible(true), Guid("A12824D8-F716-46a6-B74D-6F4E1C14AA87")]
    public class HidScale
    {
        readonly byte[] _buffer; int _offset;
        byte _reportID;
        Stream _stream;

        public HidScale()
        {
            _buffer = new byte[1024]; ReportID = 3;
        }

        public HidScale(Stream stream)
            : this()
        {
            Stream = stream;
        }

        [ComVisible(false)]
        public static string GetNameFromStatus(Status status)
        {
            return status switch
            {
                Status.Fault => "Fault",
                Status.StableAtZero => "Stable at Zero",
                Status.InMotion => "In Motion",
                Status.Stable => "Stable",
                Status.StableUnderZero => "Stable under Zero",
                Status.OverWeight => "Over Weight",
                Status.RequiresCalibration => "Requires Calibration",
                Status.RequiresRezeroing => "Requires Re-zeroing",
                _ => "",
            };
        }

        [ComVisible(false)]
        public static string GetNameFromUnit(Unit unit)
        {
            return unit switch
            {
                Unit.Milligram => "mg",
                Unit.Gram => "g",
                Unit.Kilogram => "kg",
                Unit.Ounce => "oz",
                Unit.Pound => "lb",
                _ => "",
            };
        }

        public void ReadSample(out int value, out int exponent, out Unit unit, out Status status,
                               out bool buffered)
        {
            if (Stream == null) { throw new InvalidOperationException("Stream not set."); }
            buffered = true;

            while (_offset < ReportLength)
            {
                buffered = false;
                int count = Stream.Read(_buffer, _offset, _buffer.Length - _offset);
                _offset += count;
            }

            ParseSample(_buffer, 0, out value, out exponent, out unit, out status);
            Array.Copy(_buffer, ReportLength, _buffer, 0, _offset - ReportLength); _offset -= ReportLength;
        }

        public void ParseSample(byte[] buffer, int offset,
                                out int value, out int exponent, out Unit unit, out Status status)
        {
            value = 0; exponent = 0; unit = 0; status = 0;
            if (buffer == null) { throw new ArgumentNullException(nameof(buffer)); }
            if (offset < 0 || buffer.Length - offset < ReportLength) { throw new ArgumentException("Not enough bytes.", nameof(offset)); }
            if (buffer[offset + 0] != ReportID) { throw new IOException("Unexpected report ID."); }

            value = (int)(buffer[offset + 4] | buffer[offset + 5] << 8);

            status = (Status)buffer[offset + 1]; if (status == Status.StableUnderZero) { value = -value; }
            unit = (Unit)buffer[offset + 2];
            exponent = (sbyte)buffer[offset + 3];
        }

        public byte ReportID
        {
            get { return _reportID; }
            set { _reportID = value; }
        }

        public static int ReportLength
        {
            get { return 6; }
        }

        public Stream Stream
        {
            get { return _stream; }
            set { _stream = value; }
        }

        public enum Status
        {
            Fault = 1,
            StableAtZero = 2,
            InMotion = 3,
            Stable = 4,
            StableUnderZero = 5,
            OverWeight = 6,
            RequiresCalibration = 7,
            RequiresRezeroing = 8
        }

        public enum Unit
        {
            Milligram = 1,
            Gram = 2,
            Kilogram = 3,
            Ounce = 11,
            Pound = 12
        }
    }
}
