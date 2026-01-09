export interface AddTopicRequest {
  uniqueId: string
  topics: string[]
}

// -----

export interface AddTopicResponse {
  answerId: number
  answerAt: number
  items: AddTopicResponseItem[]
}

export interface AddTopicResponseItem {
  topicId: number
  topicName: string
}
