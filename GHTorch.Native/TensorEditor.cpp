#include "TensorEditor.h"

namespace TensorEditor
{



#pragma region Create


	torch::Tensor* TensorSpace(char* start, char* end, int64_t step, bool isLog,
		int dtype, bool iskSparse, bool isCuda, int cudaIndex, bool requiresGrad) {

		auto option = CreateTensorOptions(dtype, iskSparse, isCuda, cudaIndex, requiresGrad);
		c10::Scalar startScalar, endScalar;
		GetScalar(start, dtype, startScalar);
		GetScalar(end, dtype, endScalar);

		if (isLog) {
			return CreateTensor(torch::logspace(startScalar, endScalar, step, 10, option));
		}
		else {
			return CreateTensor(torch::linspace (startScalar, endScalar, step, option));
		}
	}

	torch::Tensor* TensorArange(char* start, char* end, char* step,
		int dtype, bool iskSparse, bool isCuda, int cudaIndex, bool requiresGrad) {

		auto option = CreateTensorOptions(dtype, iskSparse, isCuda, cudaIndex, requiresGrad);
		c10::Scalar startScalar, endScalar, stepScalar;
		GetScalar(start, dtype, startScalar);
		GetScalar(end, dtype, endScalar);
		GetScalar(step, dtype, stepScalar);

		return CreateTensor(torch::arange(startScalar, endScalar, stepScalar, option));
	}

	torch::Tensor* TensorEye(int64_t n, int64_t m,
		int dtype, bool iskSparse, bool isCuda, int cudaIndex, bool requiresGrad) {

		auto option = CreateTensorOptions(dtype, iskSparse, isCuda, cudaIndex, requiresGrad);
		return CreateTensor(torch::eye(n, m, option));
	}

	torch::Tensor* TensorValue(const int64_t* longarray, int count, char* value,
		int dtype, bool iskSparse, bool isCuda, int cudaIndex, bool requiresGrad) {

		c10::Scalar scalar;
		if (GetScalar(value, dtype, scalar))
		{
			auto option = CreateTensorOptions(dtype, iskSparse, isCuda, cudaIndex, requiresGrad);
			return CreateTensor(torch::full(GetIntArray(longarray, count), scalar, option));
		}
		else {
			return TensorEmpty(longarray, count, dtype, iskSparse, isCuda, cudaIndex, requiresGrad);
		}
	}

	torch::Tensor* TensorRandom(const int64_t* longarray, int count, bool normal,
		int dtype, bool iskSparse, bool isCuda, int cudaIndex, bool requiresGrad) {

		c10::Scalar scalar;
		auto option = CreateTensorOptions(dtype, iskSparse, isCuda, cudaIndex, requiresGrad);

		if (normal)
		{
			return CreateTensor(torch::randn(GetIntArray(longarray, count), option));
		}
		else {
			return CreateTensor(torch::rand(GetIntArray(longarray, count), option));
		}
	}

	torch::Tensor* TensorRandomInt(const int64_t* longarray, int count, int64_t low, int64_t high,
		int dtype, bool iskSparse, bool isCuda, int cudaIndex, bool requiresGrad) {

		auto option = CreateTensorOptions(dtype, iskSparse, isCuda, cudaIndex, requiresGrad);

		return CreateTensor(torch::randint(low, high, GetIntArray(longarray, count), option));
	}

	torch::Tensor* TensorEmpty(const int64_t* longarray, int count,
		int dtype, bool iskSparse, bool isCuda, int cudaIndex, bool requiresGrad) {

		auto option = CreateTensorOptions(dtype, iskSparse, isCuda, cudaIndex, requiresGrad);
		auto tensor = torch::empty(GetIntArray(longarray, count), option);
		return CreateTensor(tensor);
	}

	torch::Tensor* TensorPerm(int64_t n,
		int dtype, bool iskSparse, bool isCuda, int cudaIndex, bool requiresGrad) {

		auto option = CreateTensorOptions(dtype, iskSparse, isCuda, cudaIndex, requiresGrad);
		return CreateTensor(torch::randperm(n, option));
	}


	torch::Tensor* DuplicateTensor(torch::Tensor* tensor) {
		return new torch::Tensor(*tensor);
	}

	torch::Tensor* CreateTensor(const torch::Tensor& tensor) {
		return new torch::Tensor(tensor);
	}

#pragma endregion


#pragma region Delete
	void DeleteTensor(torch::Tensor* tensor) {
		delete tensor;
	}
#pragma endregion

#pragma region Check
	const char* TensorDescription(torch::Tensor* tensor) {
		std::ostringstream stream;
		stream << *tensor;
		std::string tensor_string = stream.str();
		return tensor_string.c_str();
	}

	const char* TensorRequiresGrad(torch::Tensor* tensor, std::string*& stringInt) {
		std::ostringstream stream;
		stream << tensor->requires_grad();
		stringInt = new std::string(stream.str());
		return (*stringInt).c_str();
	}

	void DeleteString(std::string* stringInt) {
		delete stringInt;
	}

	const char* TensorDataType(torch::Tensor* tensor, std::string*& stringInt) {
		std::ostringstream stream;
		stream << tensor->dtype();
		stringInt = new std::string(stream.str());
		return (*stringInt).c_str();
	}

	const char* TensorDevice(torch::Tensor* tensor, std::string*& stringInt) {
		std::ostringstream stream;
		stream << tensor->device();
		stringInt = new std::string(stream.str());
		return (*stringInt).c_str();
	}

	const char* TensorLayout(torch::Tensor* tensor, std::string*& stringInt) {
		std::ostringstream stream;
		stream << tensor->layout();
		stringInt = new std::string(stream.str());
		return (*stringInt).c_str();
	}
#pragma endregion


	bool GetScalar(char* value, int dtype, c10::Scalar& scalar) {
		switch (dtype)
		{
		case 0://UINT8
		case 1://INT8
		case 2://INT16
		case 3://INT32
			scalar = c10::Scalar((int)strtol(value, nullptr, 10));
			return true;
		case 4://INT64
			scalar = c10::Scalar((int16_t)strtoll(value, nullptr, 10));
			return true;
		case 5://FLOAT16
		case 6://FLOAT32
			scalar = c10::Scalar(strtof(value, nullptr));
			return true;
		case 7://FLOAT64
			scalar = c10::Scalar(strtod(value, nullptr));
			return true;
		default:
			return false;
		}
	}

	torch::TensorOptions CreateTensorOptions(int dtype, bool iskSparse, bool isCuda, int cudaIndex, bool requiresGrad) {
		auto option = torch::TensorOptions();

		switch (dtype) {
		case 0: option = option.dtype(torch::kUInt8); break;
		case 1: option = option.dtype(torch::kInt8); break;
		case 2: option = option.dtype(torch::kInt16); break;
		case 3: option = option.dtype(torch::kInt32); break;
		case 4: option = option.dtype(torch::kInt64); break;
		case 5: option = option.dtype(torch::kFloat16); break;
		case 6: option = option.dtype(torch::kFloat32); break;
		case 7: option = option.dtype(torch::kFloat64); break;
		}

		if (iskSparse) {
			option = option.layout(torch::kSparse);
		}
		else {
			option = option.layout(torch::kStrided);
		}

		if (isCuda) {
			option = option.device(torch::kCUDA, cudaIndex);
		}
		else {
			option = option.device(torch::kCPU);
		}

		return option.requires_grad(requiresGrad);
	}


	c10::IntArrayRef GetIntArray(const int64_t* longarray, int count) {
		std::initializer_list<int64_t> arr = std::initializer_list<int64_t>(longarray, &(longarray[count]));
		return c10::IntArrayRef(arr);
	}

	//std::initializer_list<at::indexing::TensorIndex> GetTensorIndexArray(const int64_t* longarray, int count) {
	//	std::initializer_list<at::indexing::TensorIndex> arr = 
	//		std::initializer_list<at::indexing::TensorIndex>(longarray, &(longarray[count]));

	//}
}

