pipeline {
  agent any
  tools {
        dotnetsdk 'dotnet-sdk' // El nombre que le pusiste en la configuración
    }
  stages {
    stage('Checkout') {
      steps {
          git branch:'main',url:'https://github.com/Davidb2303/ProyectoFerreteria.git'
      }
    }

    stage('Build') {
      steps {
        sh 'dotnet test --configuration Release'
      }
    }
  }
}
