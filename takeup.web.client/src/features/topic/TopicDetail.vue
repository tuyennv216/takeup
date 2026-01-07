<template>
  <div v-if="topicManagementState.selectedItem">
    <q-table :rows="topicVotes"
             :columns="columns"
             row-key="topicId"
             flat bordered>
      <template v-slot:top>
        <div class="text-h6">{{ topicManagementState.selectedItem.topicName }}</div>
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

  import { useTopicManagementState } from '@/data/pagestate/TopicManagementState'
  import type { TopicVoteItem } from '@/features/topic/TopicDetailData'

  import { getVotes } from '@/apis/vote/VoteApis'
  import { getDataMessage } from '@/apis/data/DataApis'

  const topicVotes = ref<TopicVoteItem[]>([])
  const topicManagementState = useTopicManagementState()

  watch(
    () => topicManagementState.selectedItem,
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
            const votes: TopicVoteItem[] = detail.data.map(x => ({
              dataId: x.dataId,
              dataName: "",
              numberOfVotes: x.numberOfVotes
            }))

            topicVotes.value = votes
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
      field: (row: TopicVoteItem) => row.dataId,
      sortable: true,
    },
    {
      name: 'dataName',
      required: true,
      label: 'Mô tả',
      align: 'left',
      field: (row: TopicVoteItem) => row.dataName,
      sortable: true,
    },
    {
      name: 'numberOfVote',
      required: true,
      label: 'Votes',
      align: 'left',
      field: (row: TopicVoteItem) => row.numberOfVotes,
      sortable: true,
    },
  ];
</script>

<style scoped>
</style>
