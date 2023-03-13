<template>
  <div>
    <v-main>
      <slot></slot>
    </v-main>
  </div>
</template>

<script>

export default {
  name: 'NoHeaderLayout',
  components: {
  },

  data: () => ({
    //
  }),
  mounted() {
    console.log('OK')
  }
};
</script>
