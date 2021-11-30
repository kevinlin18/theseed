<template>
  <v-layout row wrap justify-center pa-4>
    <v-flex xs12 class="text-center">
      <h1>贈品進度查詢</h1>
    </v-flex>
    <v-flex xs12 style="max-width:800px;">
      <v-card>
        <v-layout row wrap ma-4 pa-4>
          <v-flex xs12>
            <p>
              謝謝您購買Seed彩色電視，若您想了解目前贈品處理進度，
              輸入您留下的市話或手機號碼，<br />
              將會顯示目前您的贈品處理速度，再次謝謝您的購買。
            </p> 
          </v-flex>
          <v-flex xs4 pa-2>
            <span class="title">電話號碼：</span>
          </v-flex>
          <v-flex xs8>
            <v-text-field v-model="query.phone" @keydown.enter="get()"></v-text-field>
          </v-flex>
          <v-flex xs8 offset-xs4>
            <v-btn @click="get()" color="primary">查詢</v-btn>
          </v-flex>
        </v-layout>
        <v-data-table
          :headers="headers"
          :items="items"
        >
          
        </v-data-table>
      </v-card>
    </v-flex>
  </v-layout>
</template>

<script>
// @ is an alias to /src

export default {
  name: 'Exchange',
  data(){
    return {
      headers:[
        { text: '產品類型',value:'type' },
        { text: '發票號碼',value:'receipt' },
        { text: '申請結果',value:'result' }
      ],
      items:[],
      query:{
        phone: ''
      }
    }
  },
  methods:{
    get(){
      this.items = []
      this.$ajax('search/get', this.query).then(res =>{
        this.items = res.data
      })
    }
  }
}
</script>
