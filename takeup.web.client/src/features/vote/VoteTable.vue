<template>
  <div v-if="topicManagementState.selectedTopic">
    <VoteSearch />

    <q-table :rows="topicVotes" :columns="columns" row-key="topicId" flat bordered>
      <template v-slot:top>
        <div class="text-h6">{{ topicManagementState.selectedTopic.topicName }}</div>
        <q-space />
      </template>

      <template v-slot:no-data="{ icon, message, filter }">
      </template>
    </q-table>
  </div>
</template>

<script setup lang="ts">
import { watch, ref } from 'vue'
import { QTableProps } from 'quasar'
import { uuid } from '@/utilities/common/securities'

import { useTopicManagementState } from '@/data/state/page/TopicManagementState'
import { useAppCache } from '@/data/cache/AppCache'

import type { VoteItemModel } from '@/data/model/vote/VoteItemModel'
import VoteSearch from '@/features/vote/VoteSearch.vue'

import { getVotes } from '@/apis/vote/VoteApis'

const mockVotes = [
  {
    dataId: 1,
    message: "a1",
    numberOfVotes: 10
  },
  {
    dataId: 2,
    message: "a2",
    numberOfVotes: 20
  },
  {
    dataId: 3,
    message: "a3",
    numberOfVotes: 30
  }
]

const topicVotes = ref<VoteItemModel[]>([])
const topicManagementState = useTopicManagementState()
const appCache = useAppCache()

watch(
  () => topicManagementState.selectedTopic,
  (topicItem) => {
    if (topicItem) {
      const topicDetail = getVotes({
        uniqueId: uuid(),
        topics: [{
          topicId: topicItem.topicId,
        }]
      })

      topicDetail.then(res => {
        if (res.status === 200 && res.data.items.length > 0) {
          const detail = res.data.items[0]

          const votes: VoteItemModel[] = detail.data.map(x => ({
            dataId: x.dataId,
            dataName: "",
            numberOfVotes: x.numberOfVotes
          }))

          //topicVotes.value = votes
          topicVotes.value = mockVotes

          const messages = appCache.getData(detail.data.map(x => x.dataId))

          messages.then(items => {
            const msgmap = Object.fromEntries(
              items.map(item => [item.dataId, item])
            )

            for (const topicVote of topicVotes.value) {
              topicVote.message = msgmap[topicVote.dataId]?.message || topicVote.message
            }
          })

        }
      })
    }
  }
)

const columns: QTableProps['columns'] = [
  {
    name: 'dataId',
    required: true,
    label: 'ID',
    align: 'left',
    field: (row: VoteItemModel) => row.dataId,
    sortable: true,
  },
  {
    name: 'dataName',
    required: true,
    label: 'Mô tả',
    align: 'left',
    field: (row: VoteItemModel) => row.message,
    sortable: true,
  },
  {
    name: 'numberOfVote',
    required: true,
    label: 'Votes',
    align: 'left',
    field: (row: VoteItemModel) => row.numberOfVotes,
    sortable: true,
  },
];
</script>

<style scoped></style>
