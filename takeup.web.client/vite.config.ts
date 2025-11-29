import { defineConfig } from 'vite';
import vue from '@vitejs/plugin-vue';
import { quasar, transformAssetUrls } from '@quasar/vite-plugin'
import mkcert from 'vite-plugin-mkcert';

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [
    vue({
      template: { transformAssetUrls }
    }),
    quasar({
      sassVariables: '@/default-theme.sass'
    }),
    mkcert(),
  ],
  resolve: {
    alias: {
      '@': '/src'
    }
  },
  server: {
    https: true,
    port: 50502,
  }
})
