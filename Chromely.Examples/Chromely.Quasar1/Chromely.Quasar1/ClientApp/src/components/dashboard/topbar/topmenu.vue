<template>

  <div class="col-shrink">
    <q-bar class="bg-black text-white q-px-none">

      <q-btn no-caps dense flat
             size="md"
             class="col menubutt">
        <div class="q-px-md">File</div>

        <q-menu>
          <q-list dense style="min-width: 100px">

            <q-item clickable v-close-popup @click="Open_Click">
              <q-item-section>Open...</q-item-section>
            </q-item>

            <q-item clickable v-close-popup @click="New_Click">
              <q-item-section>New</q-item-section>
            </q-item>

            <q-separator />

            <q-item clickable v-close-popup @click="Quit_Click">
              <q-item-section>Quit</q-item-section>
            </q-item>

          </q-list>
        </q-menu>


      </q-btn>

    </q-bar>
  </div>

</template>

<script src="./topmenu.ts"></script>
<style scoped lang="scss" src="./topmenu.scss"></style>
