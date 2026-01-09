import { defineStore } from 'pinia'
import type { TopicTableItem } from '@/features/topic/TopicTableItem'
import type { VoteItemModel } from '@/data/model/vote/VoteItemModel'

export interface TopicManagementState {
  search: string;
  keyword: string;
  selectedTopic: TopicTableItem | null;
  selectedVote: VoteItemModel | null;
  items: TopicTableItem[];
}

export const useTopicManagementState = defineStore('topic.management', {
  state: (): TopicManagementState => ({
    search: '',
    keyword: '',
    selectedTopic: null,
    selectedVote: null,
    items: [
      {
        topicId: 1,
        topicName: "abc",
        online: 10,
        answerAt: 5,
      },
      {
        topicId: 2,
        topicName: "def",
        online: 0,
        answerAt: 0,
      },
    ],
  }),
  persist: {
    key: 'page.topicmanagement',
    storage: localStorage,
    pick: [
      'search',
      'items',
    ]
  }
})
