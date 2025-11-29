import { apiInstance } from '@/config/configAxios'

import type { AddTopicRequest, AddTopicResponse } from '@/apis/topic/types/AddTopicTypes'

import type { GetTopicsIdRequest, GetTopicsIdResponse } from '@/apis/topic/types/GetTopicsIdTypes'

import type { UpdateTopicsRequest, UpdateTopicsResponse } from '@/apis/topic/types/UpdateTopicsTypes'

// ----- //

export const addTopic: AddTopicResponse = function (request: AddTopicRequest) {
  const response = apiInstance.post("/topic/add-topic", request)

  return response
}

// ----- //

export const getTopicsId: GetTopicsIdResponse = function (request: GetTopicsIdRequest) {
  const response = apiInstance.post("/topic/get-topics-id", request)

  return response
}

// ----- //

export const updateTopics: UpdateTopicsResponse = function (request: UpdateTopicsRequest) {
  const response = apiInstance.post("/topic/update-topic", request)

  return response
}

// ----- //
