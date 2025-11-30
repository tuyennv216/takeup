export interface TopicDetailModel {
  answerId: number
  answerAt: number

  topicId: number
  topicName: string

  items: TopicDetailDataModel[]
}

export interface TopicDetailDataModel {
  dataId: number
  message: string
  numberOfVote: number
}
