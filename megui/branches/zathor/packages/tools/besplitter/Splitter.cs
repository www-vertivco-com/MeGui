// ****************************************************************************
// 
// Copyright (C) 2005-2009  Doom9 & al
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
using System.Collections.Generic;
using System.Text;

namespace MeGUI.packages.tools.besplitter
{
    class Splitter : CommandlineJobProcessor<AudioSplitJob>
    {
        public static readonly JobProcessorFactory Factory =
  new JobProcessorFactory(new ProcessorFactory(init), "BeSplit_Splitter");

        private static IJobProcessor init(MainForm mf, Job j)
        {
            if (j is AudioSplitJob) return new Splitter(mf.Settings.BeSplitPath);
            return null;
        }

        protected override bool checkExitCode
        {
            get { return false; }
        }

        public Splitter(string exe)
        {
            executable = exe;
        }

        protected override string Commandline
        {
            get
            {
                return job.generateSplitCommandline();
            }
        }

        protected override void checkJobIO()
        {
            int endFrame = job.TheCuts.AllCuts[job.TheCuts.AllCuts.Count - 1].endFrame;
            su.ClipLength = TimeSpan.FromSeconds((double)endFrame / job.TheCuts.Framerate);
            base.checkJobIO();
        }

        public override void ProcessLine(string line, StreamType stream)
        {
            if (line.IndexOf("Writing") != -1 || line.IndexOf("Seeking") != -1)
            {
                // this is a progress line
                try
                {
                    int hours = int.Parse(line.Substring(1, 2));
                    int mins = int.Parse(line.Substring(4, 2));
                    int secs = int.Parse(line.Substring(7, 2));
                    int millis = int.Parse(line.Substring(10, 3));
                    su.ClipPosition = new TimeSpan(0, hours, mins, secs, millis);
                    return;
                }
                catch (Exception)
                {
                }
            }

            if (line.IndexOf("Usage") != -1)
                log.LogValue("Error in usage", line, MeGUI.core.util.ImageType.Error);

            base.ProcessLine(line, stream);
        }
    }
}