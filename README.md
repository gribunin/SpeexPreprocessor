# SpeexPreprocessor
Speex preprocessor wrapper for .NET

**SpeexPreprocessor** is a wrapper for speex preprocessor built in to the speex codec. The original documentation is available here: https://www.speex.org/docs/api/speex-api-reference/group__SpeexPreprocessState.html

All speex preprocessor code is compiled into the wrapper and the library doesn't have any additional dependecies.

This library allows to perform the following operations with audio in .Net program:
- AGC;
- Denoise:
- Dereverberation.
## How to use
1. First create an instance of SpeexPreprocessor:
```
var preprocessor = new Preprocessor(frameSize, sampleRate);
```
2. Set required properties (AGC, AGC values, Dereverb. Denoise:
```
                preprocessor.Agc = cbAgc.Checked;
                preprocessor.Dereverb = cbDereverb.Checked;
                preprocessor.Denoise = cbDenoise.Checked;
                preprocessor.AgcLevel = tbAgcLevel.Value;
                preprocessor.AgcMaxGain = tbAgcMaxGain.Value;
                preprocessor.AgcIncrement = tbAgcIncrement.Value;
                preprocessor.AgcDecrement = tbAgcDecrement.Value;
```
3. Start processing audio (read from file, captured from the sound device or received via network stream:
```
preprocessor.Run(_speexFrameBuffer);
```


