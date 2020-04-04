<template>
  <q-layout view="hHh LpR fFf">

    <header-component />

    <q-page-container>
      <q-page class="row no-wrap">

        <div class="col q-ma-md">
          <div class="column full-height">
            <q-scroll-area class="col q-pa-sm" visible>

              <staticpage-component />

            </q-scroll-area>
          </div>
        </div>

      </q-page>
    </q-page-container>

    <footer-component />

  </q-layout>

</template>

<script src="./dashboard.ts"></script>
