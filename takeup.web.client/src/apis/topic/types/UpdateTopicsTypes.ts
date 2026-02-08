export interface UpdateTopicsRequest {
  uniqueId: string
  topics: UpdateTopicsRequestItem[]
}

export interface UpdateTopicsRequestItem {
  topicId: number
  topicName: string
}

// -----

export interface UpdateTopicsResponse {
  answerId: number
  answerAt: number
}
