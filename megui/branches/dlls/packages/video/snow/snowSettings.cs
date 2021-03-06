// ****************************************************************************
// 
// Copyright (C) 2005  Doom9
// 
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
// 
// ****************************************************************************
using System;

namespace MeGUI
{
	/// <summary>
	/// Summary description for snowSettings.
	/// </summary>
	[Serializable]
	public class snowSettings : VideoCodecSettings
	{
		private decimal quantizer, nbMotionPredictors;
		private int predictionMode, meCompFullpel, meCompHpel, mbComp;
		private bool losslessMode;
        public override VideoCodec Codec
        {
            get { return VideoCodec.SNOW; }
        }
        public override VideoEncoderType EncoderType
        {
            get { return VideoEncoderType.SNOW; }
        }
        /// <summary>
		/// default contructor, initializes codec default values
		/// </summary>
		public snowSettings():base()
		{
			EncodingMode = 0;
			BitrateQuantizer = 700;
			quantizer = new decimal(5);
			predictionMode = 0;
			QPel = false;
			V4MV = false;
			nbMotionPredictors = 0;
			meCompFullpel = 0;
			meCompHpel = 0;
			mbComp = 0;
			losslessMode = false;
			CreditsQuantizer = new decimal(20);
            FourCCs = m_fourCCs;
		}
		#region properties

        /// I believe whe really does'nt need to create this array @ per-instance basis
        private static readonly string[] m_fourCCs = { "SNOW" };

		public int PredictionMode
		{
			get {return predictionMode;}
			set {predictionMode = value;}
		}
		public int MECompFullpel
		{
			get {return meCompFullpel;}
			set {meCompFullpel = value;}
		}
		public int MECompHpel
		{
			get {return meCompHpel;}
			set {meCompHpel = value;}
		}
		public int MBComp
		{
			get {return mbComp;}
			set {mbComp = value;}
		}
		public decimal Quantizer
		{
			get {return quantizer;}
			set {quantizer = value;}
		}
		public decimal NbMotionPredictors
		{
			get {return nbMotionPredictors;}
			set {nbMotionPredictors = value;}
		}
		public bool LosslessMode
		{
			get {return losslessMode;}
			set {losslessMode = value;}
		}
		#endregion

        public override bool UsesSAR
        {
            get { return false; }
        }
        /// <summary>
        ///  Handles assessment of whether the encoding options vary between two snowSettings instances
        /// The following are excluded from the comparison:
        /// BitrateQuantizer
        /// CreditsQuantizer
        /// Logfile
        /// Quantizer
        /// SARX
        /// SARY
        /// Zones
        /// </summary>
        /// <param name="otherSettings"></param>
        /// <returns>true if the settings differ</returns>
        public override bool IsAltered(VideoCodecSettings settings)
        {
            if (!(settings is snowSettings))
                return true;
            snowSettings otherSettings = (snowSettings)settings;
            if (
                this.CustomEncoderOptions != otherSettings.CustomEncoderOptions ||
                this.EncodingMode != otherSettings.EncodingMode ||
                this.FourCC != otherSettings.FourCC ||
                // this.FourCCs != otherSettings.FourCCs ||
                this.KeyframeInterval != otherSettings.KeyframeInterval ||
                this.LosslessMode != otherSettings.LosslessMode ||
                this.MaxQuantizer != otherSettings.MaxQuantizer ||
                this.MBComp != otherSettings.MBComp ||
                this.MECompFullpel != otherSettings.MECompFullpel ||
                this.MECompHpel != otherSettings.MECompHpel ||
                this.MinQuantizer != otherSettings.MinQuantizer ||
                this.NbBframes != otherSettings.NbBframes ||
                this.NbMotionPredictors != otherSettings.NbMotionPredictors ||
                this.PredictionMode != otherSettings.PredictionMode ||
                this.QPel != otherSettings.QPel ||
                this.Trellis != otherSettings.Trellis ||
                this.Turbo != otherSettings.Turbo ||
                this.V4MV != otherSettings.V4MV
                )
                return true;
            else
                return false;
        }
    }
}