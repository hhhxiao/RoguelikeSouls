LuaP		�	�h��}A<       @N:\FRPG\data\INTERROOT_x64\script\ai\out\256000_battle.lua        *                     	   
                                 #      �   �   �   �   �   �   (   �   �   �   �   �     �   D  B  J  I      R    
          Att3000_Dist_min    )          Att3000_Dist_max    )          Att3003_Dist_min    )          Att3003_Dist_max    )          Att3004_Dist_min 	   )          Att3004_Dist_max 
   )          Att3005_Dist_min    )          Att3005_Dist_max    )          Att3006_Dist_min    )          Att3006_Dist_max    )                 REGISTER_GOAL $       GOAL_LightKnight_Sword256000_Battle        LightKnight_Sword256000Battle         ������@333333@      @      @ffffff@�������?       REGISTER_GOAL_NO_UPDATE       �?       OnIf_256000 '       LightKnight_Sword256000Battle_Activate        LightKnight_Sword256000_Act05        LightKnight_Sword256000_Act06        LightKnight_Sword256000_Act08 %       LightKnight_Sword256000Battle_Update (       LightKnight_Sword256000Battle_Terminate '       LightKnight_Sword256000Battle_Interupt                                                                     #             ai               goal               codeNo                      HasSpecialEffectId        TARGET_SELF      ��@	       SetTimer               ^@      >@       �> E  �  � �� K?  A Y � � K?  � Y �          (    �   4   5   6   7   7   7   7   7   =   =   =   >   >   >   R   R   R   R   R   S   S   U   U   V   V   V   V   V   V   W   W   X   Y   Z   [   \   \   ]   ]   ^   _   `   a   b   b   d   e   f   g   h   i   k   k   l   l   l   l   l   l   m   n   o   p   q   q   s   t   u   v   w   x   z   z   {   {   {   {   {   {   |   }   ~      �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   	          ai     �          goal     �   
       actPerArr    �          actFuncArr    �          defFuncParamTbl    �          targetDist    �          hprate    �          atkAfterOddsTbl �   �          atkAfterFunc �   �             Att3005_Dist_max        Att3000_Dist_max        Att3003_Dist_max        Att3006_Dist_max        Att3004_Dist_max )          Common_Clear_Param        GetDist        TARGET_ENE_0 
       GetHpRate        TARGET_SELF        IsLadderAct       @      Y@�������?       IsFinishTimer               @      �?      @       @      @       @     �R@      .@      &@      "@      I@      9@     �A@      @       IsTargetGuard       4@      @      $@      D@      >@      N@     z�@       DIST_Middle      v�@     |�@     x�@       REGIST_FUNC        LightKnight_Sword256000_Act08 1       HumanCommon_ActAfter_AdjustSpace_IncludeSidestep        Common_Battle_Activate     �   
  
  
       �  Y �> �  ��K?  ���?  	���T � I@��� �@ �� �@ � 	��� � T� W�� T� �A�IB��B�I�B��� W� T� 	C�	C�IC��Ã�C��� 	D�	D�	C�	��ID�� W� T� �D �  	��� � T� 	E�	C�	D�	D�	Ã�
� 	D�	D�	C�	A�Iă	� W�� T� �D �  	��� � T� 	C��E�	D��E��Ń�� 	F�	F�	D�	A�	Ã� �D �  	��� � T� �E��E�	E�IF�	��� ID�ID�	F�	A�	��
�  A 	 
E   ��
 � A 	 
� �� ��
� A 	� 
E   ��
��A 	� 
E � E  � ��
� A 		 
E   Ɂ�E	     � 	�	 
� ��
�� � 	 
 �   � E	    	 � 
�	  ���
 	   
 �    �    Y�	�          �    .   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �             ai     -          goal     -   	       paramTbl     -          targetDist    -          fate    -             Att3005_Dist_max           GetDist        TARGET_ENE_0        GetRandam_Int       �?      Y@       AddSubGoal        GOAL_COMMON_Attack       $@     ��@       TARGET_SELF 
       DIST_None        GOAL_COMMON_ApproachTarget      [�@     z�@       DIST_Middle      �R@       GOAL_COMMON_SpinStep       @     �@               AI_DIR_TYPE_B       @       GetWellSpace_Odds     .   �> E  ��? �   � ˿ � �  	E 
� Y�˿ � � E  	  
E    Y�˿ � � A 	E  
� Y�WB � ˿  A � 	E  
�  A Y�� � �  �          �     
   �   �   �   �   �   �   �   �   �   �   �   �             ai               goal        	       paramTbl                      AddSubGoal        GOAL_COMMON_Attack       $@     ��@       TARGET_SELF 
       DIST_None        GetWellSpace_Odds                �� E  �  �   E 	Y�� � �  �          �     1   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �                         ai     0          goal     0   	       paramTbl     0          fate    0                 GetRandam_Int       �?      Y@      D@       AddSubGoal        GOAL_COMMON_LeaveTarget       @       TARGET_ENE_0       @     [�@       GOAL_COMMON_NonspinningAttack       $@      �@
       DIST_None        GOAL_COMMON_SpinStep      �@      �       AI_DIR_TYPE_B       @       GOAL_COMMON_If       .@               GetWellSpace_Odds     1   �> A  �  � W� � �� E � �  	� 
� A Y��� � �  � 	E 
Y��� �� � � � � 	 
E � Y��� � �  � 	E 
Y��� �  A Y�A � �  �          B       C  C  D            ai               goal                      GOAL_RESULT_Continue           �          I       J            ai                goal                        �          R   7  U  U  U  U  U  V  V  Y  Y  Y  Y  Z  Z  Z  Z  [  [  [  [  ]  ]  ]  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �                                   	  	  	  	  	  	  	  	  
  
  
  
  
  
  
  
            /          ai              goal              fate             fate2             fate3             targetDist             distResponse             oddsResponse      	       oddsStep      
       bkStepPer             leftStepPer             rightStepPer             safetyDist             oddsLeaveAndSide      	       timeSide      
       distLeave              distResponse 3            oddsResponse 4     	       oddsStep 5     
       bkStepPer 6            leftStepPer 7            rightStepPer 8            safetyDist 9            oddsLeaveAndSide :     	       timeSide ;     
       distLeave <            distGuardBreak_Act O            oddsGuardBreak_Act P            distMissSwing_Int c            oddsMissSwing_Int d            distUseItem_Act �            oddsUseItem_Act �            distResNear �            distResFar �            oddsResNear �            oddsResFar �            fate �            fate2 �            targetDist �            ResBehavID �            oddsResponse �     
       bkStepPer �            leftStepPer �            rightStepPer �            safetyDist �            distSuccessGuard_Act            oddsSuccessGuard_Act               Att3004_Dist_max )          IsLadderAct        TARGET_SELF        GetRandam_Int       �?      Y@       GetDist        TARGET_ENE_0       @      9@      4@      N@ffffff@      I@      @      @       FindAttack_Step_or_Guard       >@       Damaged_Step_or_Guard 333333@       GuardBreak_Act        AddSubGoal        GOAL_COMMON_Attack       $@     v�@       DIST_Middle               @       MissSwing_Int        GOAL_COMMON_ApproachTarget       �     x�@       UseItem_Act       @      *@       Shoot_2dist        GOAL_COMMON_SidewayMove      �F@     [�@       @       RebByOpGuard_Step        SuccessGuard_Act       �> E  �� T �    ? �   � ? �   � ? �   � �? � ���  A � 	A 
A �  A � �     �    �   �   �   �   ��� T � �  �   � A A �  A � E     �    �  	 �	   
! �
"  # �$  % �&�� T � �  �  �     �    � �� T� �� E � �  � ! "A #Y �  � � �     �    ! �"�� T� W� T� ��   � !� "  #E  $  %A &Y��� E  � !� "� # $A %Y �� �� E  � !� "� # $A %Y �  �  �     ! � "  # �$��   T� W� T� ��   "� #� $  %E  &  'A (Y� ��  E "� #� $� % &A 'Y  �� ��  E "� #� $� % &A 'Y  �      A !A " #? $�  & '� $? %�  ' (� %�? &� (��&� '   ( � )  * �+  , �-��'U� � �� (� *� +� ,? -A /�  0� -? . 0	 1� .� /� 0A	 1Y (T� � �� �� (� *� +� ,? -A /�  0� -? . 0	 1� .� /� 0A	 1Y ( (� )A *A +� ,�	 -   . � /  0 �1  2 �3  4� -�-T � � - -� - .
 /   0 � 1 �2  3��/�/T� �� /E 1� 2� 3� 4 5A 6Y /� / /  / /�  *      E  �  Y� �    �  A � � �   �  A 	� 
E  � Y�
"  
 
b  
 �  �   �  �  � G 
�  
 � � 
�  
� 
" 
 
b 
G 
� 
� 
� 
 � � 
�  