#pragma once

#include <torch/torch.h>

namespace PytorchInfo
{
	extern "C" __declspec(dllexport)
		void SetRandomSeed(int64_t seed);

	extern "C" __declspec(dllexport)
		void GetCUDAInfo(bool& cudaAvailble, bool& cudnnAvailble, size_t & cudaCount);
}

