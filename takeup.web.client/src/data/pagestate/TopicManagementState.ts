import { defineStore } from 'pinia'
import type { TopicTableItem } from '@/features/topic/TopicTableItem'

export interface TopicManagementState {
  search: string;
  selectedItem: TopicTableItem | null;
  items: TopicTableItem[];
}

export const useTopicManagementState = defineStore('topic-management', {
  state: (): TopicManagementState => ({
    search: '',
    selectedItem: null,
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
