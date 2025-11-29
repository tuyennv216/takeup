<template>
  <component :is="currentLayout">
    <router-view />
  </component>
</template>

<script setup lang="ts">
  import { computed } from 'vue'
  import { useQuasar } from 'quasar'
  import WebLayout from './WebLayout.vue'
  import MobileLayout from './MobileLayout.vue'
  import TabletLayout from './TabletLayout.vue'

  const $q = useQuasar()

  const currentLayout = computed(() => {
    if ($q.screen.lt.sm) return MobileLayout    // < 600px
    if ($q.screen.lt.md) return TabletLayout    // 600px - 1024px
    return WebLayout                            // > 1024px
  })
</script>
