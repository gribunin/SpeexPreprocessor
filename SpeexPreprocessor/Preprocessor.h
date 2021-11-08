#pragma once

using namespace System;

typedef struct SpeexPreprocessState_ SpeexPreprocessState;

namespace SpeexPreprocessor
{
	public ref class Preprocessor : IDisposable
	{
	public:
		/// <summary>
		/// Creates a new preprocessor. You MUST create one preprocessor per channel processed.
		/// </summary>
		/// <param name="frameSize">Number of samples to process at one time (should correspond to 10-20 ms). Must be the same value as that used for the echo canceller for residual echo cancellation to work.</param>
		/// <param name="samplingRate">Sampling rate used for the input.</param>
		Preprocessor(int frameSize, int samplingRate);
		~Preprocessor();

		/// <summary>
		/// Preprocess a frame
		/// </summary>
		/// <param name="buffer">Audio sample vector (in and out). Must be same size as specified in constructor.</param>
		/// <returns>Bool value for voice activity (1 for speech, 0 for noise/silence), ONLY if VAD turned on.</returns>
		bool Run(array<short>^ buffer);

		/// <summary>
		/// Preprocess a frame
		/// </summary>
		/// <param name="buffer">Audio sample vector (in and out). Must be same size as specified in constructor multipled by sizeof(short) -- 2</param>
		/// <returns>Bool value for voice activity (1 for speech, 0 for noise/silence), ONLY if VAD turned on.</returns>
		bool Run(array<unsigned char>^ buffer);

		// Preprocessor Automatic Gain Control state
		property bool Agc {
			bool get();
			void set(bool value);
		}

		/// <summary>
		/// Preprocessor Automatic Gain Control level
		/// </summary>
		property int AgcLevel {
			int get();
			void set(int value);
		}

		/// <summary>
		/// Maximal gain increase in dB/second
		/// </summary>
		property int AgcIncrement {
			int get();
			void set(int value);
		}

		/// <summary>
		/// Maximal gain decrease in dB/second
		/// </summary>
		property int AgcDecrement {
			int get();
			void set(int value);
		}

		/// <summary>
		/// Maximal gain in dB 
		/// </summary>
		property int AgcMaxGain {
			int get();
			void set(int value);
		}

		/// <summary>
		/// Preprocessor denoiser state
		/// </summary>
		property bool Denoise {
			bool get();
			void set(bool value);
		}

		/// <summary>
		/// Preprocessor dereverb state
		/// </summary>
		property bool Dereverb {
			bool get();
			void set(bool value);
		}
	private:
		SpeexPreprocessState* _state;
	};
}
