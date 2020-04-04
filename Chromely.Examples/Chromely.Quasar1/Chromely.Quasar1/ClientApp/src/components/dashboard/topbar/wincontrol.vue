<template>

  <div class="col-shrink">
    <q-bar class="bg-black text-white q-pa-none">

      <q-btn dense flat
             size="md"
             icon="mdi-window-minimize"
             @click="minimiseWindow"
             class="col winbutt" />

      <q-btn dense flat
             size="md"
             icon="mdi-window-restore"
             @click="restoreWindow"
             v-if="isMaximised"
             class="col winbutt" />

      <q-btn dense flat
             size="md"
             icon="mdi-crop-square"
             @click="maximiseWindow"
             v-if="!isMaximised"
             class="col winbutt" />

      <q-btn dense flat
             size="md"
             icon="mdi-close"
             @click="closeWindow"
             class="col winbutt" />

    </q-bar>
  </div>

</template>

<script src="./wincontrol.ts"></script>
<style scoped lang="scss" src="./wincontrol.scss"></style>
