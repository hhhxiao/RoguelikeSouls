LuaP		�	�h��}A<       @N:\FRPG\data\INTERROOT_x64\script\ai\out\006420_battle.lua        B                  	                                                 !   %   %   %   %   �   *   �   �   �       �   5  5    G  G  :  e  e  e  M    k  �  �  �  �  �  �  �  �  �  �  �    �          �  "  �            NormalR_min    A          NormalR_max    A          Guard_NormalR_min    A          Guard_NormalR_max    A          LargeR_min 	   A          LargeR_max 
   A          Whand_jyaku_min    A          Whand_jyaku_max    A          Whand_kyou_min    A          Whand_kyou_max    A   
       PushR_min    A   
       PushR_max    A   
       Magic_min    A   
       Magic_max    A          Backstep_Atk_min    A          Backstep_Atk_max    A          Rolling_Atk_min    A          Rolling_Atk_max    A                  REGISTER_GOAL        GOAL_Ninja6420_Battle        Ninja6420Battle                @      �?ffffff@������ @ffffff
@�������?333333@      �?ffffff@ffffff@       REGISTER_GOAL_NO_UPDATE       �?       Ninja6420Battle_Activate        Ninja6420_Act01        Ninja6420_Act02        Ninja6420_Act03        Ninja6420_Act04        Ninja6420_Act05        Ninja6420_Act06        Ninja6420_Act07        Ninja6420_Act08        Ninja6420_Act09        Ninja6420_Act10        Ninja6420_Act11        Ninja6420_Battle_Attack_After        Ninja6420Battle_Update        Ninja6420Battle_Terminate        Ninja6420Battle_Interupt            *     �   -   -   2   3   4   5   5   5   5   5   :   :   :   :   ;   ;   ;   ;   <   <   <   <   =   =   =   >   >   >   >   >   >   >   >   G   G   H   I   J   K   L   L   O   O   P   Q   R   S   T   T   V   V   X   X   X   X   X   X   Y   Z   [   \   ]   ]   `   a   b   c   d   f   i   i   k   k   k   k   k   k   l   m   n   o   p   p   s   t   u   v   w   y   ~   ~   ~   ~   ~   ~      �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   
          ai     �          goal     �   
       actPerArr    �          actFuncArr    �          defFuncParamTbl    �          fate    �          fate2    �          BothHandOff    �          targetDist    �          atkAfterFunc �   �       .   
       StartDash        Common_Clear_Param        GetRandam_Int       �?      Y@       GetDist        TARGET_ENE_0        AddObserveArea                TARGET_SELF        AI_DIR_TYPE_B       D@      @       @      &@      @      (@      @      @      6@      I@ffffff@      $@      .@       @       IsTargetGuard      �A@      "@      4@      A@      @       REGIST_FUNC        Ninja6420_Act01        Ninja6420_Act02        Ninja6420_Act03        Ninja6420_Act04        Ninja6420_Act05        Ninja6420_Act06        Ninja6420_Act07        Ninja6420_Act08        Ninja6420_Act09        Ninja6420_Act10        Ninja6420_Act11        Ninja6420_ActAfter_AdjustSpace        atkAfterOddsTbl        Common_Battle_Activate     �   �> Y 
  
  
  E     �  Y ? �   � ? �   	� ? �  	 
� �? � 
��K@ 	 � E � �  Y 	�� T� 	�~��IC��C��� �� T� 	�~IĄ	ąID��C��� � T� �D 	� ��	� 
�� T� ��~I	Ņ	Ċ�C�� ��~�ń	ą	ĊIA��	� �~ T� �D 	� ��	� 
�� T� ��~I	ŅI��	Ċ� 	�~IĄIą�Ã	Ċ�� �D 	� ��	� 
�� �� ��~�Ą�Ņ�D��Ã	ĊT� I�~�ń	ą	D�I���� 	   
 �  � 	I�~� 	   
 � E � 	I�� 	   
 � � � 	I��� 	   
 � � � 	I�� 	   
 � 	 � 	I��� 	   
 � E	 � 	I�� 	   
 � �	 � 	I�� 	   
 � �	 � 	I��� 	   
 � 
 � 	I��� 	   
 � E
 � 	I�� 	   
 � �
 � 	I�� 	   
 � �
  ��	E 
    �    � �  Y�
�          �    g   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �             ai     f          goal     f   	       paramTbl     f          targetDist    f          fate    f             NormalR_max           GetDist        TARGET_ENE_0        GetRandam_Int       �?      Y@       CommonNPC_ChangeWepR1        AddSubGoal        GOAL_COMMON_ApproachTarget       @       TARGET_SELF       �      >@#       GOAL_COMMON_ComboAttackTunableSpin       $@       NPC_ATK_NormalR        DIST_Middle       �?     �V@       GOAL_COMMON_ComboFinal               N@       GOAL_COMMON_ComboRepeat        NPC_ATK_LargeR        GetWellSpace_Odds     g   �> E  ��? �   � E     � Y�� �  E  	  
E   � Y�WA �� �  A � 	E  
�  A Y�� � A � 	E  
� � � Y�� �C �� �  A � 	E  
�  A Y�� E A � 	E  
� � � Y�� � A � 	E  
� � � Y��� �  A � 	E  
�  A Y�� E A � 	E  
� � � Y�� � A � 	E  
�  A Y� � �  �          �    g   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �                                                                                                                                                                                        ai     f          goal     f   	       paramTbl     f          targetDist    f          fate    f             Guard_NormalR_max           GetDist        TARGET_ENE_0        GetRandam_Int       �?      Y@       CommonNPC_ChangeWepR1        AddSubGoal        GOAL_COMMON_ApproachTarget       @       TARGET_SELF       @      >@#       GOAL_COMMON_ComboAttackTunableSpin       $@       NPC_ATK_NormalR        DIST_Middle       �?     �V@       GOAL_COMMON_ComboFinal               �      N@       GOAL_COMMON_ComboRepeat        NPC_ATK_LargeR        GetWellSpace_Odds     g   �> E  ��? �   � E     � Y�� �  E  	  
E   � Y�WA �� �  A � 	E  
�  A Y�� � A � 	E  
� �  Y�� �C �� �  A � 	E  
�  A Y�� � A � 	E  
� �  Y�� � A � 	E  
� �  Y��� �  A � 	E  
�  A Y�� � A � 	E  
� �  Y�� � A � 	E  
�  A Y�    �             9                         %  %  %  %  %  %  %  %  %  (  (  )  )  )  )  )  )  )  )  )  *  *  *  .  .  .  .  .  .  .  .  .  /  /  /  /  /  /  /  /  /  0  0  4  4  5            ai     8          goal     8   	       paramTbl     8          targetDist    8          fate    8             LargeR_max           GetDist        TARGET_ENE_0        GetRandam_Int       �?      Y@       CommonNPC_ChangeWepR1        AddSubGoal        GOAL_COMMON_ApproachTarget       @       TARGET_SELF       @      >@#       GOAL_COMMON_ComboAttackTunableSpin       $@       NPC_ATK_LargeR        DIST_Middle       �?     �V@       GetWellSpace_Odds        GOAL_COMMON_ComboFinal               �    9   �> E  ��? �   � E     � Y�� �  E  	  
E   � Y�WA �� �  A � 	E  
�  A Y� � �� �  A � 	E  
�  A Y�� � A � 	E  
�  A Y� � �  �          :      <  <  <  =  =  =  =  ?  ?  ?  ?  ?  ?  ?  ?  ?  B  B  B  B  B  B  B  B  B  D  D  F  F  G            ai               goal        	       paramTbl               targetDist              fate          
       PushR_max           GetDist        TARGET_ENE_0        GetRandam_Int       �?      Y@       AddSubGoal        GOAL_COMMON_ApproachTarget       @       TARGET_SELF       �#       GOAL_COMMON_ComboAttackTunableSpin       $@       NPC_ATK_PushR        DIST_Middle       �?     �V@       GetWellSpace_Odds        �> E  ��? �   � ˿ � � E  	  
   A Y�˿ � �  	E  
E � � Y�    �          M   H   O  O  O  P  P  P  P  Q  Q  Q  S  S  S  S  U  U  U  V  V  V  V  V  V  V  V  V  W  W  W  W  W  W  W  W  W  W  Y  Y  Y  Z  Z  Z  Z  Z  Z  Z  Z  Z  [  [  [  [  [  [  [  [  [  [  ^  ^  ^  ^  ^  ^  ^  ^  ^  b  b  d  d  e            ai     G          goal     G   	       paramTbl     G          targetDist    G          fate    G          R_Wep 
   G      
       Magic_max 
       Magic_min           GetDist        TARGET_ENE_0        GetRandam_Int       �?      Y@       GetWepCateRight        TARGET_SELF        CommonNPC_ChangeWepR2        AddSubGoal        GOAL_COMMON_ApproachTarget       @      �#       GOAL_COMMON_ComboAttackTunableSpin       $@       NPC_ATK_MagicR        DIST_Middle       �?       GOAL_COMMON_LeaveTarget        GetWellSpace_Odds             H   �> E  ��? �   � �? � ���     � Y�  �  �� �� E � 	E  
  �   � Y���  A 	� 
E  �  A Y��� � �� �� �� E � 	E  
� �   � Y���  A 	� 
E  �  A Y�� ��  A 	� 
E  �  A Y�� � �  �          k    "   m  m  m  n  n  n  n  p  p  p  p  y  y  y  y  y  y  y  y  y  z  z  z  z  z  z  z  z  z  |  |  ~  ~              ai     !          goal     !   	       paramTbl     !          targetDist    !          fate    !                 GetDist        TARGET_ENE_0        GetRandam_Int       �?      Y@       CommonNPC_ChangeWepR1        AddSubGoal #       GOAL_COMMON_ComboAttackTunableSpin       $@       NPC_ATK_BackstepB       @      �?     �V@       GOAL_COMMON_ComboFinal        NPC_ATK_NormalR        DIST_Middle               �       GetWellSpace_Odds     "   �> E  ��? �   � E     � Y�� �  E 	E  
� �  Y�� E  � 	E  
�  A Y� � �  �          �   +   �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �            ai     *          goal     *   	       paramTbl     *          targetDist    *          fate    *             Rolling_Atk_max           GetDist        TARGET_ENE_0        GetRandam_Int       �?      Y@       CommonNPC_ChangeWepR1        AddSubGoal        GOAL_COMMON_ApproachTarget       @       TARGET_SELF       @#       GOAL_COMMON_ComboAttackTunableSpin       $@       NPC_ATK_StepF       @      �?     �V@       GOAL_COMMON_ComboFinal        NPC_ATK_NormalR        DIST_Middle               �       GetWellSpace_Odds     +   �> E  ��? �   � E     � Y�� �  E  	  
E   � Y�� �  E 	E  
� �  Y�� E  � 	E  
�  A Y� � �  �          �    #   �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �            ai     "          goal     "   	       paramTbl     "          targetDist    "          fate    "                 GetDist        TARGET_ENE_0        GetRandam_Int       �?      Y@       CommonNPC_ChangeWepR1        AddSubGoal        GOAL_COMMON_TurnAround       @       AI_DIR_TYPE_B       $@      @#       GOAL_COMMON_ComboAttackTunableSpin        NPC_ATK_LargeR        DIST_Middle       �?     �V@       GetWellSpace_Odds             #   �> E  ��? �   � E     � Y�� �  E  	E 
�   � � Y �  � E 	E  
� �  Y�� G E  �          �       �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �            ai               goal        	       paramTbl               targetDist              fate                     GetDist        TARGET_ENE_0        GetRandam_Int       �?      Y@       AddSubGoal        GOAL_COMMON_SpinStep       $@       NPC_ATK_StepB                AI_DIR_TYPE_B        @       GetWellSpace_Odds        �> E  ��? �   � ˿ � �  	E  
A � � Y�A    �          �       �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �            ai               goal        	       paramTbl               targetDist              fate                     GetDist        TARGET_ENE_0        GetRandam_Int       �?      Y@       AddSubGoal #       GOAL_COMMON_ComboAttackTunableSpin       $@       NPC_ATK_SwitchWep        DIST_Middle       �?     �V@       GetWellSpace_Odds                �> E  ��? �   � ˿ � �  	E  
E � � Y�A    �          �       �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �            ai               goal        	       paramTbl               targetDist              fate                     GetDist        TARGET_ENE_0        GetRandam_Int       �?      Y@       AddSubGoal        GOAL_COMMON_ApproachTarget       @       @       TARGET_SELF       �       GOAL_COMMON_TurnAround       @       AI_DIR_TYPE_B       $@      @       GetWellSpace_Odds                �> E  ��? �   � ˿ � � E  	 
E   � Y�˿ �  E  	E 
�   � � Y A    �          �    Q   �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �              ai     P          goal     P          fate    P          fate2    P   	       MoveDist 	   P                 GetRandam_Int       �?      Y@      @       CommonNPC_ChangeWepL1       9@      I@       AddSubGoal        GOAL_COMMON_SpinStep       $@       NPC_ATK_StepB        TARGET_ENE_0                AI_DIR_TYPE_F      �R@       NPC_ATK_StepL        NPC_ATK_StepR        GOAL_COMMON_LeaveTarget       @      @       GOAL_COMMON_SidewayMove        @     �V@      ^@    Q   �> A  �  � �> A  �  � �       � Y��? T� � T� K�  A � 	� 
 E  Y�� � T� K�  A � 	� 
 E  Y�
� K�  A  	� 
 E  Y��� �� � K� E �> �  
� � � 	  
�   � Y��� K�  A � 	�> 
 A  � 
�> � � �   � � Y �                                 ai               goal                      GOAL_RESULT_Continue           �                             ai                goal                        �          "       $  $  $  %  %  %  %  &  &  &  &  '  '  '  '  +  +  +  +  +  ,  -  .  /  /  0  0  1  1  3  3  3  3  3  3  3  3  3  4  4  :  :  :  :  :  ;  <  =  =  >  >  ?  ?  A  A  A  A  A  A  A  A  A  B  B  H  H  H  H  H  I  J  K  K  L  L  M  M  O  O  P  P  P  P  P  P  P  P  P  P  P  P  P  R  R  R  R  R  R  R  R  R  T  T  Z  Z  Z  Z  Z  [  \  \  ]  ]  _  _  `  `  `  `  `  `  `  `  `  `  b  b  b  b  b  b  b  b  b  b  b  b  d  d  i  i  i  i  i  j  k  l  l  m  m  n  n  o  o  q  q  r  r  r  r  r  r  r  r  r  r  t  t  t  t  t  t  t  t  t  t  t  t  u  x  x  y  y  y  y  y  z  z  {  }  }  ~  ~  ~  ~  ~      �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �  �            ai     �          goal     �          targetDist    �          fate    �          fate2    �          fate3    �          FindATKDist    (          FindATKPer    (   	       MoveDist    (          Suc_GuardDist .   @          Suc_GuardPer /   @          combRunDist F   g          combRunPer G   g          shootIntPer m   �          ResDist �   �          ResPer �   �       +          GetDist        TARGET_ENE_0        GetRandam_Int       �?      Y@       IsInterupt        INTERUPT_FindAttack       @      I@       ClearSubGoal        AddSubGoal        GOAL_COMMON_SpinStep       $@       NPC_ATK_StepB                AI_DIR_TYPE_F        INTERUPT_SuccessGuard #       GOAL_COMMON_ComboAttackTunableSpin        NPC_ATK_LargeR 
       DIST_None       �       INTERUPT_Damaged        GOAL_COMMON_LeaveTarget       @      @       INTERUPT_Shoot       &@      (@       TARGET_SELF         INTERUPT_ReboundByOpponentGuard       >@
       Replaning        GOAL_COMMON_Wait �������?       INTERUPT_Inside_ObserveArea        IsFinishTimer 	       SetTimer        CommonNPC_ChangeWepR1        GOAL_COMMON_ApproachTarget 333333�?       NPC_ATK_NormalR        DIST_Middle       �?       �> E  ��? �   � ? �   � ? �   � �? � �� �� �  � � �� ׁ � �� 	Y 	� 	�  E E  � � � Y�	� 	 	�?  �� �� �  � �� ׁ � �� Y � E 
 � E  � �  Y��  �? E �� T� �  � T� ׁ �� �� Y �� � � � 
? � � � E    E     Y�� � � 
 E E  � � � Y��  �? E �� ��  �� �� �� Y �� T� � � 	 
E E  � � � Y��� � � 	 
? � � �  � �  Y��  �? E �� �� � � � � ׁ �	� �� Y � � �� T� � � 
 E E  � � � Y�T� � � 
 ? � � �  � �  Y�� KF Y �  
A E  Y��  �� �� Y �  
A E  Y�KF Y �  �� �� Y �  
A E  Y�KF Y �  �? � �� �� KG � ��� � T� �G �  	Y �� Y E	     � Y�� �	 � 	E  
�	     Y�� E  	
 
E  E
 �
  Y��     �  B      E  �  Y� �    �  A �  � �  � �   	�  
A �  � �  �  A � E  � Y�"   b   �  G �   � � �   � � "  �  b  �    G � � �  � � "  b G � � � � "  b G � � � � �  