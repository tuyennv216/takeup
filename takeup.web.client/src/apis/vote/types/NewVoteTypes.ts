export interface NewVoteRequest {
  uniqueId: string
  topicId: number
  dataId: number
}

// -----

export interface NewVoteResponse {
  answerId: number
  answerAt: number
}
