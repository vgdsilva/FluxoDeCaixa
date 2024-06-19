import React, { Children, Component, useEffect, useState } from "react";
import { View, Text, StyleSheet } from "react-native";
import Ionicons from '@expo/vector-icons/Ionicons';

export interface CollapseViewProps{
    children?: React.ReactNode;
    title?: string,
    icon?: string,
    isExpanded?: boolean
}

export const CollapseView: React.FC<CollapseViewProps> = ({children, title = "", isExpanded = false}) => {

  const [isExpandedState, setIsExpandedState] = useState(isExpanded);

  
  const toggleExpansion = () => { setIsExpandedState(!isExpandedState); };

  return(
          <View style={styles.container}>
              <View style={styles.header}>
                  <Text style={styles.title}>{title}</Text>
                  <View style={styles.expandeButton}>
                    <Ionicons name={isExpanded ? 'caret-down-outline' : 'caret-up-outline'}
                              size={24}
                              color="white"
                              onPress={toggleExpansion} />
                  </View>
              </View>
              {isExpandedState && children}
          </View>
  );
}

const styles = StyleSheet.create({
    container: {
      backgroundColor: '#202024',
      flexDirection: 'column',
    },
    title: {
        color: 'white',
        fontSize: 16
    },
    expandeButton: {
      borderRadius: 8,
      backgroundColor: '#121212',
      alignContent: 'center'
    },
    header: {
      flexDirection: 'row',
      justifyContent: 'space-between',
      padding: 24,
    },
    containerContent: {
      padding: 24
    }
  });