import type { AxiosResponse } from 'axios';
import { apiInstance } from '@/config/configAxios'

import type { AddDataRequest, AddDataResponse } from '@/apis/data/types/AddDataTypes'

import type { GetDataIdRequest, GetDataIdResponse } from '@/apis/data/types/GetDataByIdTypes'

import type { GetDataMessageRequest, GetDataMessageResponse } from '@/apis/data/types/GetDataByMessageTypes'

import type { UpdateDataRequest, UpdateDataResponse } from '@/apis/data/types/UpdateDataTypes'

// -----

export async function addData(request: AddDataRequest) {
  const response: AxiosResponse<AddDataResponse> = await apiInstance.post("/data/add-data", request)

  return response
}

// -----

export async function getDataId(request: GetDataIdRequest) {
  const response: AxiosResponse<GetDataIdResponse> = await apiInstance.post("/data/get-data-id", request)

  return response
}

// -----

export async function getDataMessage(request: GetDataMessageRequest) {
  const response: AxiosResponse<GetDataMessageResponse> = await apiInstance.post("/data/add-data-message", request)

  return response
}

// -----

export async function updateData(request: UpdateDataRequest) {
  const response: AxiosResponse<UpdateDataResponse> = await apiInstance.post("/data/update-data", request)

  return response
}
