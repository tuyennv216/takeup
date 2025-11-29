<template>
</template>

<script setup lang="ts">
  import { onMounted } from 'vue'
  import { useRouter } from 'vue-router'

  import redirectBus from '@/utilities/redirect/redirectBus'

  onMounted(() => {
    const router = useRouter()

    redirectBus.on("to", data => {
      router.push({
        path: data.path,
        query: data.param || {}
      })
    })
  })
</script>
