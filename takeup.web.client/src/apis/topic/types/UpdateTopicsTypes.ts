export interface GetTopicsIdRequest {
  topics: GetTopicsIdRequestItem[]
}

export interface GetTopicsIdRequestItem {
  topicId: number
  topicName: string
}

// ----- //

export interface GetTopicsIdResponse {
  answerId: number
  answerAt: number
}

// ----- //
