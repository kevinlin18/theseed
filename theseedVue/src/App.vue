<template>
  <v-app>
    <v-app-bar
      app
      color="primary"
      dark
    >
      <div class="d-flex align-center">
        <v-img
          alt="Vuetify Logo"
          class="shrink mr-2"
          contain
          src="https://cdn.vuetifyjs.com/images/logos/vuetify-logo-dark.png"
          transition="scale-transition"
          width="40"
        />
      </div>
      <span class="title">Seed 登錄送贈品</span>
      <v-spacer></v-spacer>
      <v-btn to="/" text>
        <span>首頁</span>
      </v-btn>
      <v-btn to="/exchange" text>
        <span>贈品兌換登錄</span>
      </v-btn>
      <v-btn to="/search" text>
        <span>贈品進度查詢</span>
      </v-btn>
    </v-app-bar>

    <v-content>
      <router-view />
    </v-content>
  </v-app>
</template>

<script>
export default {
  name: 'App',


  data: () => ({
    //
  }),
};
</script>
