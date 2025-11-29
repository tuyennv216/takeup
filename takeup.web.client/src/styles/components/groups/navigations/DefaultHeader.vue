<template>
  <q-header class="bg-primary text-white" unelevated>
    <q-toolbar class="bg-primary text-white">
      <q-btn flat dense round
             @click="menuClick"
             aria-label="Menu"
             icon="menu" />

      <q-toolbar-title class="cursor-pointer"
                       @click="goToHome">
        Home
      </q-toolbar-title>
    </q-toolbar>
  </q-header>
</template>

<script setup lang="ts">
  import { useRouter } from 'vue-router'
  import { useLayoutState } from '@/data/appstate/LayoutState'

  const router = useRouter()

  const goToHome = () => {
    router.push('/')
  }

  const menuClick = () => {
    const layoutState = useLayoutState()
    layoutState.toggleMenu()
    console.log(layoutState.menuOpened)
  }
</script>

<style scoped>
  .cursor-pointer {
    cursor: pointer;
  }
</style>
