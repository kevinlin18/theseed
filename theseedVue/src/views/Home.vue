<template>
  <v-layout row wrap justify-center pa-4>
    <v-flex xs12 class="text-center">
      <img alt="Vue logo" src="../assets/logo.svg" height="200">
      <h1>活動說明</h1>
    </v-flex>
    <v-flex xs12 style="max-width:500px;">
      <p>
        Seed牌彩色電視機買就送活動贈品，兌換方式如下：
        <ol>
          <li v-for="(guide, index) in guides" :key="index">
            {{ guide }}
          </li>
        </ol>
      </p>
    </v-flex>
  </v-layout>
</template>

<script>
// @ is an alias to /src

export default {
  name: 'Home',
  data(){
    return {
      guides:[
        '登錄：基本資料、產品資料',
        '上傳：保固卡、發票檔案',
        '送出：同意個資規範、確認送出',
        '審核：經審核無誤，贈品將於10個工作天寄出給您',
      ]
    }
  }
}
</script>
