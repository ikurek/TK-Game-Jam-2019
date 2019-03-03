using System;

namespace Progress {
	
	public enum Epoch {
		Intro,
		First,
		Second,
		Third,
		Fourth,
		Final
	}

	public static class EpochUtil {
		public static string epochName(Epoch epoch) {
			switch (epoch) {
				case Epoch.Intro: return "Intro";
				case Epoch.First: return "First";
				case Epoch.Second: return "Second";
				case Epoch.Third: return "Third";
				case Epoch.Fourth: return "Fourth";
				case Epoch.Final: return "Final";
				default: return "You Forgot To Give It A Name, Dummy";
			}
		}

		public static Epoch next(Epoch epoch) {
			switch (epoch) {
				case Epoch.Intro: return Epoch.First;
				case Epoch.First: return Epoch.Second;
				case Epoch.Second: return Epoch.Third;
				case Epoch.Third: return Epoch.Fourth;
				case Epoch.Fourth: return Epoch.Final;
				case Epoch.Final: return Epoch.Final;
				default: return Epoch.Intro;
			}
		}
	}
	
}
