<template>
  <q-drawer v-show="layoutStore.menuOpened"
            v-model="layoutStore.menuOpened"
            overlay
            bordered
            class="bg-grey-2"
            :width="280">
    <div class="menu-left">
      <q-list>
        <q-item clickable v-ripple @click="redirect('/')">
          <q-item-section avatar>
            <q-icon name="home" />
          </q-item-section>
          <q-item-section>Trang chủ</q-item-section>
        </q-item>
      </q-list>

      <!--<q-list>
        <q-item clickable v-ripple @click="redirect('/about')">
          <q-item-section avatar>
            <q-icon name="about" />
          </q-item-section>
          <q-item-section>About</q-item-section>
        </q-item>
      </q-list>-->
    </div>
  </q-drawer>
</template>

<script setup lang="ts">
  //import { onMounted, ref } from 'vue'

  import { redirect } from '@/utilities/redirect/redirectUtil'
  import { useLayoutState } from '@/utilities/storage/LayoutState'
  const layoutStore = useLayoutState()

</script>

<style scoped>
  .menu-left {
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    height: 100%;
  }
</style>
