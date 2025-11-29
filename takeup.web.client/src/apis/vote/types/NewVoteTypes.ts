export interface NewVoteRequest {
  votes: NewVoteRequestItem[]
}

export interface NewVoteRequestItem {
  topicId: number
  dataId: string
}

// ----- //

export interface NewVoteResponse {
  answerId: number
  answerAt: number
}

// ----- //
