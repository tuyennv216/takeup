export interface GetTopicsIdRequest {
  uniqueId: string
  topics: string[]
}

// -----

export interface GetTopicsIdResponse {
  answerId: number
  answerAt: number
  items: GetTopicsIdResponseTopicItem[]
}

export interface GetTopicsIdResponseTopicItem {
  topicId: number
  topicName: string
}
