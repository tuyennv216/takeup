<template>
  <div>
    <TopicSearch />
    <q-table :rows="topicManagementState.items"
             :columns="columns"
             row-key="topicId"
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
  import TopicApis from '@/apis/topic/TopicApis'

  import { useTopicManagementState } from '@/data/pagestate/TopicManagementState'
  import type { TopicTableItem } from '@/features/topic/TopicTableItem'

  var topicManagementState = useTopicManagementState()
  // 1. Định nghĩa Columns cho q-table
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

  // Hàm tiện ích để định dạng timestamp (ví dụ: sang định dạng ngày giờ)
  const formatTimestamp = (timestamp: number): string => {
    if (!timestamp) return 'Chưa có';
    // Chuyển đổi mili giây (giả sử là mili giây) sang đối tượng Date
    const date = new Date(timestamp);
    return date.toLocaleString(); // Định dạng tùy theo locale
  };

</script>
