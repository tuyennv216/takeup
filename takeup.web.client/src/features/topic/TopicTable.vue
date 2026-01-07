<template>
  <div>
    <TopicSearch />
    <q-table :rows="topicManagementState.items"
             :columns="columns"
             row-key="topicId"
             @row-click="onTopicClick"
             flat bordered>

      <template v-slot:body-cell-answerAt="props">
        <q-td :props="props">
          {{ formatTimestamp(props.row.answerAt) }}
        </q-td>
      </template>

      <template v-slot:no-data="{ icon, message, filter }"></template>
    </q-table>
  </div>
</template>

<script setup lang="ts">
  import { onMounted, ref } from 'vue'
  import { QTableProps } from 'quasar'

  import TopicSearch from '@/features/topic/TopicSearch.vue'

  import { useTopicManagementState } from '@/data/pagestate/TopicManagementState'
  import type { TopicTableItem } from '@/features/topic/TopicTableItem'

  const topicManagementState = useTopicManagementState()
  const columns: QTableProps['columns'] = [
    {
      name: 'topicId',
      required: true,
      label: 'ID',
      align: 'left',
      field: (row: TopicTableItem) => row.topicId,
      sortable: true,
    },
    {
      name: 'topicName',
      required: true,
      label: 'Chủ Đề',
      align: 'left',
      field: (row: TopicTableItem) => row.topicName,
      sortable: true,
    },
    {
      name: 'online',
      required: true,
      label: 'Online',
      align: 'left',
      field: (row: TopicTableItem) => row.online,
      sortable: true,
    },
  ];

  const onTopicClick = (evt: any, row: TopicTableItem, index: number) => {
    console.log(row)
    topicManagementState.selectedItem = row;
  };

  const formatTimestamp = (timestamp: number): string => {
    if (!timestamp) return 'Chưa có';
    const date = new Date(timestamp);
    return date.toLocaleString();
  };

</script>
