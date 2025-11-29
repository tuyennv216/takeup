<template>
  <q-btn color="primary"
         unelevated
         :class="buttonClasses"
         :style="buttonStyle"
         v-bind="filteredAttrs"
         no-caps>
    <slot />
  </q-btn>
</template>

<script lang="ts">
  import { defineComponent, computed } from 'vue'

  export default defineComponent({
    name: 'BtnBase',
    inheritAttrs: false,
    props: {
      min: Boolean,
      width: String,
      height: String,
      widthLevel: String,
      padding: String,
      margin: String,
    },
    setup(props, { attrs }) {
      const buttonClasses = computed(() => ({
        'btn-footer': true,
        'style-min': props.min,
        'style-normal': !props.min
      }))

      const buttonStyle = computed(() => {
        const style: Record<string, string> = {}

        if (props.width) {
          style.width = props.width
        } else if (props.widthLevel && Number.parseInt(props.widthLevel) > 0) {
          style.width = Number.parseInt(props.widthLevel) * 40 + 'px'
        } else if (!props.min) {
          style.minWidth = '80px'
        }

        if (props.height)  style.height = props.height
        if (props.padding) style.padding = props.padding
        if (props.margin) style.margin = props.margin

        return style
      })

      // Loại bỏ props đã xử lý khỏi attrs
      const filteredAttrs = computed(() => {
        const { min, width, ...otherAttrs } = attrs
        return otherAttrs
      })

      return {
        buttonClasses,
        buttonStyle,
        filteredAttrs
      }
    }
  })
</script>

<style scoped>
  .btn-footer {
    height: auto;
    min-height: auto;
  }

  .style-normal {
    padding: 1px 12px;
  }

  .style-min {
    min-width: auto;
    padding: 0;
  }
</style>
