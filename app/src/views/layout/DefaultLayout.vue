<template>
  <div>
    <MenuApp />
    <v-main>
      <slot></slot>
    </v-main>
  </div>
</template>

<script>
import MenuApp from '@/components/MenuApp'

export default {
  name: 'DefaultLayout',
  components: {
    MenuApp
  },

  data: () => ({
    //
  }),
  mounted() {
    console.log('OK')
  }
};
</script>
