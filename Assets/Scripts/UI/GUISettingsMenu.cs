using System.Globalization;
using TMPro;
using UnityEngine;
using static HardCoded.VRigUnity.FileDialogUtils;

namespace HardCoded.VRigUnity {
	public class GUISettingsMenu : MonoBehaviour {
		[SerializeField] GUIScript settings;
		[SerializeField] TMP_InputField inputFieldModelX;
		[SerializeField] TMP_InputField inputFieldModelY;
		[SerializeField] TMP_InputField inputFieldModelZ;
		[SerializeField] GameObject cameraConfigWindow;
		[SerializeField] GameObject backgroundConfigWindow;

		public void SelectModel() {
			var extensions = new [] {
				new CustomExtensionFilter("VRM Files", "vrm"),
				new CustomExtensionFilter("All Fil1es", "*"),
			};

			FileDialogUtils.OpenFilePanel(this, "Open File", Settings.ModelFile, extensions, false, (paths) => {
				if (paths.Length > 0) {
					string filePath = paths[0];
					settings.LoadVrmModel(filePath);
				}
			});
		}

		public void ResetModel() {
			settings.ResetModel();
		}

		private bool TryParseFloat(string s, out float value) {
			return float.TryParse(
				string.IsNullOrEmpty(s) ? "0" : s,
				NumberStyles.Number,
				CultureInfo.GetCultureInfo("en-US"),
				out value
			);
		}

		public void SetModelTransform() {
			if (!TryParseFloat(inputFieldModelX.text, out float x)
			|| !TryParseFloat(inputFieldModelY.text, out float y)
			|| !TryParseFloat(inputFieldModelZ.text, out float z)) {
				return;
			}

			settings.SetModelTransform(x, y, z);
		}

		public void SetBackgroundColor(Color color) {
			settings.SetBackgroundColor(color);
		}

		public void ResetCamera() {
			settings.ResetCamera();
		}

		public void SetShowCamera(bool show) {
			settings.SetShowCamera(show);
		}

		public void OpenCameraSettings() {
			cameraConfigWindow.SetActive(true);
		}

		public void OpenBackgroundSettings() {
			backgroundConfigWindow.SetActive(true);
		}

		public void OpenGithub() {
			Application.OpenURL("https://github.com/Kariaro/VRigUnity");
		}
	}
}
