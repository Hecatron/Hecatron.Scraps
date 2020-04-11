<template>

  <q-bar class="bg-black text-white q-px-none">

    <q-icon name="mdi-home" class="q-px-lg" />

    <topmenu-component />

    <div class="col text-center text-weight-bold nonselectable"
         v-if="isChromely">
      App Title
    </div>

    <div class="col text-center text-weight-bold nonselectable"
         v-if="!isChromely">
      App Title
    </div>

    <wincontrol-component v-if="isChromely" ref="wincontrol" />

  </q-bar>

</template>

<script src="./topbar.ts"></script>
<style scoped lang="scss" src="./topbar.scss"></style>
