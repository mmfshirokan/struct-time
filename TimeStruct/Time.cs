using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;

namespace TimeStruct
{
    /// <summary>
    /// Struct Time represents the times in 24-hours format without date.
    /// </summary>
    public struct Time
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Time"/> struct.
        ///  First constructur.
        /// </summary>
        /// <param name="minutes"> Number of minuts, can be any integer. </param>
        public Time(int minutes)
            : this(0, minutes)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Time"/> struct.
        /// Second constructor.
        /// </summary>
        /// <param name="hours" > Number of horse, can be any integer. </param>
        /// <param name="minutes"> Number of minuts, can be any integer. </param>
        public Time(int hours, int minutes)
        {
            this.Hours = (hours + (minutes / 60)) % 24;
            this.Minutes = minutes % 60;

            if (this.Minutes < 0)
            {
                this.Hours -= 1;
                this.Minutes = 60 + this.Minutes;
            }

            if (this.Hours < 0)
            {
                this.Hours = 24 + this.Hours;
            }
        }

        /// <summary>
        /// Gets property.
        /// </summary>
        public readonly int Hours { get; }

        /// <summary>
        /// Gets property.
        /// </summary>
        public readonly int Minutes { get; }

        /// <summary>
        /// Gives representation of given time in string format "Minuts : Horse.
        /// </summary>
        /// <returns> String representation of the Time. </returns>
        public string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(DigitToString(this.Hours / 10));
            result.Append(DigitToString(this.Hours % 10));
            result.Append(':');
            result.Append(DigitToString(this.Minutes / 10));
            result.Append(DigitToString(this.Minutes % 10));
            return result.ToString();
        }

        /// <summary>
        /// Deconstruct for object decomposition.
        /// </summary>
        /// <param name="hours"> Given hours. </param>
        /// <param name="minutes"> Given minutes. </param>
        public void Deconstruct(out int hours, out int minutes)
        {
            minutes = this.Minutes;
            hours = this.Hours;
        }

        private static char DigitToString(int number) => number switch
        {
            0 => '0',
            1 => '1',
            2 => '2',
            3 => '3',
            4 => '4',
            5 => '5',
            6 => '6',
            7 => '7',
            8 => '8',
            9 => '9',
            _ => ':',
        };
    }
}
