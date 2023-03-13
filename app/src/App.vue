<template>
  <v-app class="bg-default">
    <component :is="layout">
      <transition name="fade" mode="out-in">
        <router-view></router-view>
      </transition>
    </component>
  </v-app>
</template>

<script>
const default_layout = "default";

export default {
  name: 'AppMain',
  components: {
  },

  data: () => ({
    //
  }),
  computed: {
    layout() {
      return (this.$route.meta.layout || default_layout) + '-layout';
    }
  },
  mounted() {
    console.log('OK')
  }
};
</script>

<style>
.v-tabs-slider-wrapper {
  color: #FF0000;
}

</style>
