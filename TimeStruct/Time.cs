using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;

namespace TimeStruct
{
    /// <summary>
    /// Struct Time represents the times in 24-hours format without date.
    /// </summary>
    public readonly struct Time
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
        public Time(int hours, int minutes) => (this.Hours, this.Minutes) = TimeConvert(hours, minutes);

        /// <summary>
        /// Gets property.
        /// </summary>
        public int Hours { get; }

        /// <summary>
        /// Gets property.
        /// </summary>
        public int Minutes { get; }

        /// <summary>
        /// Gives representation of given time in string format "Minuts : Horse.
        /// </summary>
        /// <returns> String representation of the Time. </returns>
        public new string ToString()
        {
            var result = new StringBuilder();
            result.Append(this.Hours / 10);
            result.Append(this.Hours % 10);
            result.Append(':');
            result.Append(this.Minutes / 10);
            result.Append(this.Minutes % 10);
            return result.ToString();
        }

        /// <summary>
        /// Deconstruct for object decomposition.
        /// </summary>
        /// <param name="hours"> Given hours. </param>
        /// <param name="minutes"> Given minutes. </param>
        public void Deconstruct(out int hours, out int minutes) => (minutes, hours) = (this.Minutes, this.Hours);

        private static (int, int) TimeConvert(int hours, int minutes)
        {
            int resHours = (hours + (minutes / 60)) % 24;
            int resMinutes = minutes % 60;

            if (resMinutes < 0)
            {
                resHours -= 1;
                resMinutes = 60 + resMinutes;
            }

            if (resHours < 0)
            {
                resHours = 24 + resHours;
            }

            return (resHours, resMinutes);
        }
    }
}
