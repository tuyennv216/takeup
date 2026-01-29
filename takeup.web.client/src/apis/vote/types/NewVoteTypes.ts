export interface NewVoteRequest {
  uniqueId: string
  votes: NewVoteRequestItem[]
}

export interface NewVoteRequestItem {
  topicId: number
  dataId: number
}

// -----

export interface NewVoteResponse {
  answerId: number
  answerAt: number
}
