<template>
  <q-footer class="bg-grey-2 text-black app-footer" unelevated>
    <q-toolbar class="app-footer-toolbar">
      <q-toolbar-title class="text-center app-footer-toolbar-title">
        <div class="app-footer-left">
          <slot name="left" />
        </div>

        <div class="app-footer-middle">
          <slot name="middle" />
        </div>

        <div class="app-footer-right">
          <slot name="right" />
        </div>
      </q-toolbar-title>
    </q-toolbar>
  </q-footer>
</template>

<script lang="ts">
  import { defineComponent } from 'vue'

  export default defineComponent({
    name: 'AppFooter'
  })
</script>

<style scoped>
  .app-footer {
    height: 32px;
    min-height: 32px;
    max-height: 32px;
  }

  .app-footer-toolbar {
    min-height: 32px !important;
    padding: 0 4px;
  }

  .app-footer-toolbar-title {
    display: flex;
    flex-direction: row;
    flex-grow: 1;
    justify-content: space-between;
    align-items: center;
  }

  .app-footer-left {
    display: flex;
    flex-direction: row;
    gap: 4px;
    align-items: center;
    justify-content: flex-start;
    /* Cho phép phần tử này co lại nhưng không mở rộng */
    flex: 0 1 auto;
  }

  .app-footer-middle {
    display: flex;
    flex-direction: row;
    gap: 4px;
    align-items: center;
    justify-content: center;
    /* Giữ phần tử giữa ở chính giữa bằng cách căn giữa tuyệt đối */
    position: absolute;
    left: 50%;
    transform: translateX(-50%);
  }

  .app-footer-right {
    display: flex;
    flex-direction: row;
    gap: 4px;
    align-items: center;
    justify-content: flex-end;
    /* Cho phép phần tử này co lại nhưng không mở rộng */
    flex: 0 1 auto;
    margin-left: auto; /* Đẩy phần tử này sang bên phải */
  }
</style>
