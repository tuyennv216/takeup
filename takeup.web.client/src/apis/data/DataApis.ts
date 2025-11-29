import { apiInstance } from '@/config/configAxios'

import type { AddDataRequest, AddDataResponse } from '@/apis/data/types/AddDataTypes'

import type { GetDataIdRequest, GetDataIdResponse } from '@/apis/data/types/GetDataIdTypes'

import type { GetDataMessageRequest, GetDataMessageResponse } from '@/apis/data/types/GetDataMessageTypes'

import type { UpdateDataRequest, UpdateDataResponse } from '@/apis/data/types/UpdateDataTypes'

// ----- //

export const addData: AddDataResponse = function (request: AddDataRequest) {
  const response = apiInstance.post("/data/add-data", request)

  return response
}

// ----- //

export const getDataId: GetDataIdResponse = function (request: GetDataIdRequest) {
  const response = apiInstance.post("/data/get-data-id", request)

  return response
}

// ----- //

export const getDataMessage: GetDataMessageResponse = function (request: GetDataMessageRequest) {
  const response = apiInstance.post("/data/add-data-message", request)

  return response
}

// ----- //

export const updateData: UpdateDataResponse = function (request: UpdateDataRequest) {
  const response = apiInstance.post("/data/update-data", request)

  return response
}

// ----- //
