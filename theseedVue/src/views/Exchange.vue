<template>
  <v-layout row wrap justify-center pa-4>
    <v-flex xs12 class="text-center">
      <h1>贈品兌換登錄</h1>
    </v-flex>
    <v-flex xs12 style="max-width:800px;">
      <v-card>
        <!-- <v-card-text> -->
          <v-layout row wrap ma-2 pa-2>
            <v-flex xs12>
              <h2>基本資料</h2>
            </v-flex>
            <v-flex xs12 sm4 md2 py-4>
              <span class="title">姓名：</span>
            </v-flex>
            <v-flex xs12 sm8 md4>
              <v-text-field v-model="query.name"></v-text-field>
            </v-flex>
            <v-flex xs12 sm4 md2 py-4>
              <span class="title">電話：</span>
            </v-flex>
            <v-flex xs12 sm8 md4>
              <v-text-field v-model="query.phone"></v-text-field>
            </v-flex>
            <v-flex xs12 sm4 md2 py-4>
              <span class="title">地址：</span>
            </v-flex>
            <v-flex xs12 sm8 md4>
              <v-text-field v-model="query.address"></v-text-field>
            </v-flex>
            <v-flex xs12>
              <h2>產品資料</h2>
            </v-flex>
            <v-flex xs12 sm4 md2 py-4>
              <span class="title">類型：</span>
            </v-flex>
            <v-flex xs12 sm8 md4>
              <v-select :items="dropdown.type" v-model="query.type"></v-select>
            </v-flex>
            <v-flex xs12 sm4 md2 py-4>
              <span class="title">發票號碼：</span>
            </v-flex>
            <v-flex xs12 sm8 md4>
              <v-text-field v-model="query.receipt"></v-text-field>
            </v-flex>
            <!-- <v-flex xs12 sm4 md2 py-4>
              <span class="title">購買日期：</span>
            </v-flex>
            <v-flex xs12 sm8 md4>
              <v-menu
                ref="menu"
                v-model="menu"
                :close-on-content-click="false"
                :return-value.sync="date"
                offset-y
                min-width="290px"
              >
                <template v-slot:activator="{ on }">
                  <v-text-field
                    v-model="query.date"
                    prepend-icon="mdi-calendar"
                    readonly
                    v-on="on"
                  ></v-text-field>
                </template>
                <v-date-picker v-model="query.date" no-title scrollable>
                  <v-spacer></v-spacer>
                  <v-btn text color="primary" @click="menu = false">Cancel</v-btn>
                  <v-btn text color="primary" @click="$refs.menu.save(query.date)">OK</v-btn>
                </v-date-picker>
              </v-menu>
            </v-flex> -->
            <v-flex xs12>
              <h2>購買證明</h2>
            </v-flex>
            <v-flex xs12 sm4 md2 py-4>
              <span class="title">發票：</span>
            </v-flex>
            <v-flex xs12 sm8 md4>
              <v-file-input v-model="query.fileReceipt"></v-file-input>
            </v-flex>
            <!-- <v-flex xs12 sm4 md2 py-4>
              <span class="title">保固卡：</span>
            </v-flex>
            <v-flex xs12 sm8 md4>
              <v-file-input v-model="query.fileGuarantee"></v-file-input>
            </v-flex> -->
            <v-flex xs12>
              <ol>
                <li v-for="(guide, index) in guides" :key="index">
                  {{ guide }}
                </li>
              </ol>
            </v-flex>
            <v-flex xs12>
              
              <v-checkbox
                v-model="checkbox"
                label="我已詳閱並同意活動規則"
              ></v-checkbox>
              <v-btn @click="create()" color="primary" :disabled="!checkbox">確認送出</v-btn>
            </v-flex>
          </v-layout>
        <!-- </v-card-text> -->
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
        { text: '產品活動',value:'' },
        { text: '產品序號',value:'' },
        { text: '申請結果',value:'' }
      ],
      items:[],
      guides:[
        '依機種型號不同，贈品內容略有不同，贈品顏色隨機出貨，以實物為準。',
        '若有退貨及換貨情形發生，Seed將保留追回贈品之權力。',
        '贈品若缺貨或兌換完畢，Seed有權更換替代等值贈品。'
      ],
      dropdown:{
        type:[
          {value:'', text:'請選擇……'},
          {value:'液晶電視機', text:'液晶電視機'},
          {value:'電漿電視機', text:'電漿電視機'},
          {value:'平面電視機', text:'平面電視機'},
          {value:'映像管電視機', text:'映像管電視機'},
        ]
      },
      checkbox: false,
      menu: false,
      query:{
        name:'Jack',
        phone:'0921123123',
        address:'Tainan',
        type:'平面電視機',
        receipt:'ZZ12341234',
        fileReceipt: null,
      //   name:'',
      //   phone:'',
      //   address:'',
      //   type:'',
      //   receipt:'',
      //   fileReceipt: null,
        // date:'',
        // fileGuarantee: null
      }
    }
  },
  methods:{
    create(){
      let formData = new FormData()
      formData.append('name', this.query.name)
      formData.append('phone', this.query.phone)
      formData.append('address', this.query.address)
      formData.append('type', this.query.type)
      formData.append('receipt', this.query.receipt)
      formData.append('fileReceipt', this.query.fileReceipt)
      this.$ajax('exchange/create', formData).then(res =>{
      if (res.data.success) {
        this.$router.push('search')
      } else {
        window.alert('Error: ' + res.data.message)
      }
      })
    }
  }
}
</script>
