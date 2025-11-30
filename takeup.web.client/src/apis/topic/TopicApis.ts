import type { AxiosResponse } from 'axios';
import { apiInstance } from '@/config/configAxios'

import type { AddTopicRequest, AddTopicResponse } from '@/apis/topic/types/AddTopicTypes'

import type { GetTopicsIdRequest, GetTopicsIdResponse } from '@/apis/topic/types/GetTopicsIdTypes'

import type { UpdateTopicsRequest, UpdateTopicsResponse } from '@/apis/topic/types/UpdateTopicsTypes'

// -----

export async function addTopic(request: AddTopicRequest) {
  const response: AxiosResponse<AddTopicResponse> = await apiInstance.post("/topic/add-topic", request)

  return response
}

// -----

export async function getTopicsId(request: GetTopicsIdRequest) {
  const response: AxiosResponse<GetTopicsIdResponse> = await apiInstance.post("/topic/get-topics-id", request)

  return response
}

// -----

export async function updateTopics(request: UpdateTopicsRequest) {
  const response: AxiosResponse<UpdateTopicsResponse> = await apiInstance.post("/topic/update-topic", request)

  return response
}
