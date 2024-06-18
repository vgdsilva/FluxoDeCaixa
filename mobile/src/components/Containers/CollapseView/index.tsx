import React, { Children, Component, useEffect } from "react";
import { View, Text, StyleSheet } from "react-native";
import Ionicons from '@expo/vector-icons/Ionicons';

export interface CollapseViewProps {
    title?: string,
    icon?: string,
}

export const CollapseView = (props: CollapseViewProps & any) => {

    

    return(
            <View style={styles.container}>
                <View style={styles.header}>
                    <Text style={styles.title}>{props.title}</Text>
                    <Ionicons name="caret-down-outline"
                              size={24} 
                              color="white"/>
                </View>
            </View>
    );
}

const styles = StyleSheet.create({
    container: {
      backgroundColor: '#202024',
      flexDirection: 'column',
      gap: 16
    },
    title: {
        color: 'white',
        fontSize: 16
    },
    header: {
      flexDirection: 'row',
      justifyContent: 'space-between',
      padding: 24,
    }
  });