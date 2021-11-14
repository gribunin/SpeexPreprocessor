#include "speex/speex_preprocess.h"

#include "Preprocessor.h"
#include "SpeexException.h"

using namespace System;
using namespace SpeexPreprocessor;

Preprocessor::Preprocessor(int frameSize, int samplingRate)
{
	_state = speex_preprocess_state_init(frameSize, samplingRate);
}

Preprocessor::~Preprocessor()
{
	if (_state)
	{
		speex_preprocess_state_destroy(_state);
		_state = nullptr;
	}
}

bool Preprocessor::Run(array<short>^ buffer)
{
	pin_ptr<spx_int16_t> pinnedBuffer = &buffer[0];
	return speex_preprocess_run(_state, pinnedBuffer) > 0;
}

bool Preprocessor::Run(array<unsigned char>^ buffer)
{
	pin_ptr<unsigned char> pinnedBuffer = &buffer[0];
	return speex_preprocess_run(_state, (spx_int16_t*)pinnedBuffer) > 0;
}

bool GetBoolValue(SpeexPreprocessState* state, int request)
{
	spx_int32_t val;
	if (speex_preprocess_ctl(state, request, &val) != 0)
	{
		throw gcnew SpeexException();
	}

	return val > 0;
}

int GetIntValue(SpeexPreprocessState* state, int request)
{
	int val;
	if (speex_preprocess_ctl(state, request, &val) != 0)
	{
		throw gcnew SpeexException();
	}

	return val;
}

int GetFloatValue(SpeexPreprocessState* state, int request)
{
	float val;
	if (speex_preprocess_ctl(state, request, &val) != 0)
	{
		throw gcnew SpeexException();
	}

	return val;
}

void SetBoolValue(SpeexPreprocessState* state, bool value, int request)
{
	spx_int32_t val = value ? 1 : 0;
	if (speex_preprocess_ctl(state, request, &val) != 0)
	{
		throw gcnew SpeexException();
	}
}

void SetIntValue(SpeexPreprocessState* state, int value, int request)
{
	if (speex_preprocess_ctl(state, request, &value) != 0)
	{
		throw gcnew SpeexException();
	}
}

void SetFloatValue(SpeexPreprocessState* state, float value, int request)
{
	if (speex_preprocess_ctl(state, request, &value) != 0)
	{
		throw gcnew SpeexException();
	}
}

bool Preprocessor::Agc::get()
{
	return GetBoolValue(_state, SPEEX_PREPROCESS_GET_AGC);
}

void Preprocessor::Agc::set(bool value)
{
	SetBoolValue(_state, value, SPEEX_PREPROCESS_SET_AGC);
}

float Preprocessor::AgcLevel::get()
{
	return GetFloatValue(_state, SPEEX_PREPROCESS_GET_AGC_LEVEL);
}

void Preprocessor::AgcLevel::set(float value)
{
	SetFloatValue(_state, value, SPEEX_PREPROCESS_SET_AGC_LEVEL);
}

int Preprocessor::AgcIncrement::get()
{
	return GetIntValue(_state, SPEEX_PREPROCESS_GET_AGC_INCREMENT);
}

void Preprocessor::AgcIncrement::set(int value)
{
	SetIntValue(_state, value, SPEEX_PREPROCESS_SET_AGC_INCREMENT);
}

int Preprocessor::AgcDecrement::get()
{
	return GetIntValue(_state, SPEEX_PREPROCESS_GET_AGC_DECREMENT);
}

void Preprocessor::AgcDecrement::set(int value)
{
	SetIntValue(_state, value, SPEEX_PREPROCESS_SET_AGC_DECREMENT);
}

int Preprocessor::AgcMaxGain::get()
{
	return GetIntValue(_state, SPEEX_PREPROCESS_GET_AGC_MAX_GAIN);
}

void Preprocessor::AgcMaxGain::set(int value)
{
	SetIntValue(_state, value, SPEEX_PREPROCESS_SET_AGC_MAX_GAIN);
}

bool Preprocessor::Denoise::get()
{
	return GetBoolValue(_state, SPEEX_PREPROCESS_GET_DENOISE);
}

void Preprocessor::Denoise::set(bool value)
{
	SetBoolValue(_state, value, SPEEX_PREPROCESS_SET_DENOISE);
}

bool Preprocessor::Dereverb::get()
{
	return GetBoolValue(_state, SPEEX_PREPROCESS_GET_DEREVERB);
}

void Preprocessor::Dereverb::set(bool value)
{
	SetBoolValue(_state, value, SPEEX_PREPROCESS_SET_DEREVERB);
}