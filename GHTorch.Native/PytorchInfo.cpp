#include "PytorchInfo.h"

namespace PytorchInfo
{
	void SetRandomSeed(int64_t seed) {
		torch::manual_seed(seed);
	}

	void GetCUDAInfo(bool& cudaAvailble, bool& cudnnAvailble, size_t& cudaCount) {
		cudaAvailble = torch::cuda::is_available();
		cudnnAvailble = torch::cuda::cudnn_is_available();
		cudaCount = torch::cuda::device_count();
	}
};
