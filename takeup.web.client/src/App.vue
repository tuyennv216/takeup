<template>
  <main class="full-width">
    <AutoLayout></AutoLayout>
  </main>

  <div>
    <RedirectInject />
  </div>
</template>

<script setup lang="ts">
  import AutoLayout from '@/styles/layouts/devices/AutoLayout.vue'
  import RedirectInject from '@/utilities/redirect/RedirectInject.vue'
</script>

<style scoped>
</style>
