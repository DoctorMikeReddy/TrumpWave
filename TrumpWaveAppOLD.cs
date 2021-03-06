/ /   T h i s   g a m e   p r e s e n t s   t h e   c u r r e n t   D E F C O N   s t a t u s   o n   y o u r   S i f t e o   c u b e s .  
 / /   S t o p   T r u m p   f r o m   e x p l o d i n g :  
 / /   *   P r e s s   T r u m p :   C h a n g e   G a m e   M o d e  
 / /   *   F l i p :   T u r n   t h e   c u b e s   o v e r   i n   D E F C O N   o r d e r ,   t h e n   b a c k   a g a i n   i n   r e v e r s e   o r d e r  
 / /       t o   d e - e s c a l a t e   t h e   e m e r g e n c y .   E f f e c t i v e l y   a   f o r e   a n d   b a c k   M e x i c a n   W a v e  
 / /   *   N e i g h b o u r :   N o t   i m p l e m e n t e d   y e t  
 / /   *   T i l t :   N o t   i m p l e m e n t e d   y e t  
 / /   *   S h a k e :   N o t   i m p l e m e n t e d   y e t  
 / /  
 / /   T h i s   p r o g r a m   d e m o n s t r a t e s   t h e   f o l l o w i n g   c o n c e p t s :  
 / /  
 / /   *   E v e n t   h a n d l i n g   b a s i c s  
 / /   *   C u b e   s e n s o r   e v e n t s  
 / /   *   I m a g e   d r a w i n g   b a s i c s  
 / /  
 / /   I n   a d d i t i o n   t o   i l l u s t r a t i n g   A P I s   a n d   p r o g r a m m i n g   c o n c e p t s ,   t h i s   d e m o   c a n   b e  
 / /   a   u s e f u l   u t i l i t y   f o r   q u i c k l y   t e s t i n g   g r a p h i c s .   J u s t   d r o p   y o u r   i m a g e s   i n t o  
 / /   t h i s   p r o j e c t ' s   ` a s s e t s / i m a g e s `   d i r e c t o r y ,   b u n d l e   y o u r   a s s e t s   i n   t h e  
 / /   I m a g e H e l p e r   t o o l ,   a n d   r e l o a d   t h e   g a m e   t o   c h e c k   t h e m   o u t .  
 / /   - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
  
 u s i n g   S y s t e m ;  
 u s i n g   S y s t e m . C o l l e c t i o n s ;  
 u s i n g   S y s t e m . C o l l e c t i o n s . G e n e r i c ;  
 u s i n g   S i f t e o ;  
  
 n a m e s p a c e   T r u m p W a v e   {  
  
     p u b l i c   c l a s s   T r u m p W a v e A p p   :   B a s e A p p   {  
  
         p u b l i c   S t r i n g [ ]   m I m a g e N a m e s ;  
         p u b l i c   L i s t < C u b e W r a p p e r >   m W r a p p e r s   =   n e w   L i s t < C u b e W r a p p e r > ( ) ;  
         p u b l i c   R a n d o m   m R a n d o m   =   n e w   R a n d o m ( ) ;  
  
         / /   H e r e   w e   i n i t i a l i z e   o u r   a p p .  
         p u b l i c   o v e r r i d e   v o i d   S e t u p ( )   {  
  
             / /   L o a d   u p   t h e   l i s t   o f   i m a g e s .  
             m I m a g e N a m e s   =   L o a d I m a g e I n d e x ( ) ;  
  
             / /   L o o p   t h r o u g h   a l l   t h e   c u b e s   a n d   s e t   t h e m   u p .  
             f o r e a c h   ( C u b e   c u b e   i n   C u b e S e t )   {  
  
                 / /   C r e a t e   a   w r a p p e r   o b j e c t   f o r   e a c h   c u b e .   T h e   w r a p p e r   o b j e c t   a l l o w s   u s  
                 / /   t o   b u n d l e   a   c u b e   w i t h   e x t r a   i n f o r m a t i o n   a n d   b e h a v i o r .  
                 C u b e W r a p p e r   w r a p p e r   =   n e w   C u b e W r a p p e r ( t h i s ,   c u b e ) ;  
                 m W r a p p e r s . A d d ( w r a p p e r ) ;  
                 w r a p p e r . D r a w S l i d e ( ) ;  
             }  
  
             / /   # #   E v e n t   H a n d l e r s   # #  
             / /   O b j e c t s   i n   t h e   S i f t e o   A P I   ( p a r t i c u l a r l y   B a s e A p p ,   C u b e S e t ,   a n d   C u b e )  
             / /   f i r e   e v e n t s   t o   n o t i f y   a n   a p p   o f   v a r i o u s   h a p p e n i n g s ,   i n c l u d i n g   a c t i o n s  
             / /   t h a t   t h e   p l a y e r   p e r f o r m s   o n   t h e   c u b e s .  
             / /  
             / /   T o   l i s t e n   f o r   a n   e v e n t ,   j u s t   a d d   t h e   h a n d l e r   m e t h o d   t o   t h e   e v e n t .   T h e  
             / /   h a n d l e r   m e t h o d   m u s t   h a v e   t h e   c o r r e c t   s i g n a t u r e   t o   b e   a d d e d .   R e f e r   t o  
             / /   t h e   A P I   d o c u m e n t a t i o n   o r   l o o k   a t   t h e   e x a m p l e s   b e l o w   t o   g e t   a   s e n s e   o f  
             / /   t h e   c o r r e c t   s i g n a t u r e s   f o r   v a r i o u s   e v e n t s .  
             / /  
             / /   * * N e i g h b o r A d d E v e n t * *   a n d   * * N e i g h b o r R e m o v e E v e n t * *   a r e   t r i g g e r e d   w h e n  
             / /   t h e   p l a y e r   p u t s   t w o   c u b e s   t o g e t h e r   o r   s e p a r a t e s   t w o   n e i g h b o r e d   c u b e s .  
             / /   T h e s e   e v e n t s   a r e   f i r e d   b y   C u b e S e t   i n s t e a d   o f   C u b e   b e c a u s e   t h e y   i n v o l v e  
             / /   i n t e r a c t i o n   b e t w e e n   t w o   C u b e   o b j e c t s .   ( T h e r e   a r e   C u b e - l e v e l   n e i g h b o r  
             / /   e v e n t s   a s   w e l l ,   w h i c h   c o m e s   i n   h a n d y   i n   c e r t a i n   s i t u a t i o n s ,   b u t   m o s t  
             / /   o f   t h e   t i m e   y o u   w i l l   f i n d   t h e   C u b e S e t - l e v e l   e v e n t s   t o   b e   m o r e   u s e f u l . )  
             C u b e S e t . N e i g h b o r A d d E v e n t   + =   O n N e i g h b o r A d d ;  
             C u b e S e t . N e i g h b o r R e m o v e E v e n t   + =   O n N e i g h b o r R e m o v e ;  
         }  
  
         / /   # #   N e i g h b o r   A d d   # #  
         / /   T h i s   m e t h o d   i s   a   h a n d l e r   f o r   t h e   N e i g h b o r A d d   e v e n t .   I t   i s   t r i g g e r e d   w h e n  
         / /   t w o   c u b e s   a r e   p l a c e d   s i d e   b y   s i d e .  
         / /  
         / /   C u b e 1   a n d   c u b e 2   a r e   t h e   t w o   c u b e s   t h a t   a r e   i n v o l v e d   i n   t h i s   n e i g h b o r i n g .  
         / /   T h e   t w o   c u b e   a r g u m e n t s   c a n   b e   i n   a n y   o r d e r ;   i f   y o u r   l o g i c   d e p e n d s   o n  
         / /   c u b e s   b e i n g   i n   s p e c i f i c   p o s i t i o n s   o r   r o l e s ,   y o u   n e e d   t o   a d d   l o g i c   t o  
         / /   t h i s   h a n d l e r   t o   s o r t   t h e   t w o   c u b e s   o u t .  
         / /  
         / /   S i d e 1   a n d   s i d e 2   a r e   t h e   s i d e s   t h a t   t h e   c u b e s   n e i g h b o r e d   o n .  
         p r i v a t e   v o i d   O n N e i g h b o r A d d ( C u b e   c u b e 1 ,   C u b e . S i d e   s i d e 1 ,   C u b e   c u b e 2 ,   C u b e . S i d e   s i d e 2 )     {  
             L o g . D e b u g ( " N e i g h b o r   a d d :   { 0 } . { 1 }   < - >   { 2 } . { 3 } " ,   c u b e 1 . U n i q u e I d ,   s i d e 1 ,   c u b e 2 . U n i q u e I d ,   s i d e 2 ) ;  
  
             C u b e W r a p p e r   w r a p p e r   =   ( C u b e W r a p p e r ) c u b e 1 . u s e r D a t a ;  
             i f   ( w r a p p e r   ! =   n u l l )   {  
                 / /   H e r e   w e   s e t   o u r   w r a p p e r ' s   r o t a t i o n   v a l u e   s o   t h a t   t h e   i m a g e   g e t s  
                 / /   d r a w n   w i t h   i t s   t o p   s i d e   p o i n t i n g   t o w a r d s   t h e   n e i g h b o r   c u b e .  
                 / /  
                 / /   C u b e . S i d e   i s   a n   e n u m e r a t i o n   ( T O P ,   L E F T ,   B O T T O M ,   R I G H T ,   N O N E ) .   T h e  
                 / /   v a l u e s   o f   t h e   e n u m e r a t i o n   c a n   b e   c a s t   t o   i n t e g e r s   b y   c o u n t i n g  
                 / /   c o u n t e r c l o c k w i s e :  
                 / /  
                 / /   *   T O P   =   0  
                 / /   *   L E F T   =   1  
                 / /   *   B O T T O M   =   2  
                 / /   *   R I G H T   =   3  
                 / /   *   N O N E   =   4  
                 w r a p p e r . m R o t a t i o n   =   ( i n t ) s i d e 1 ;  
                 w r a p p e r . m N e e d D r a w   =   t r u e ;  
             }  
  
             w r a p p e r   =   ( C u b e W r a p p e r ) c u b e 2 . u s e r D a t a ;  
             i f   ( w r a p p e r   ! =   n u l l )   {  
                 w r a p p e r . m R o t a t i o n   =   ( i n t ) s i d e 2 ;  
                 w r a p p e r . m N e e d D r a w   =   t r u e ;  
             }  
  
         }  
  
         / /   # #   N e i g h b o r   R e m o v e   # #  
         / /   T h i s   m e t h o d   i s   a   h a n d l e r   f o r   t h e   N e i g h b o r R e m o v e   e v e n t .   I t   i s   t r i g g e r e d  
         / /   w h e n   t w o   c u b e s   t h a t   w e r e   n e i g h b o r e d   a r e   s e p a r a t e d .  
         / /  
         / /   T h e   s i d e   a r g u m e n t s   f o r   t h i s   e v e n t   a r e   t h e   s i d e s   t h a t   t h e   c u b e s  
         / /   _ w e r e _   n e i g h b o r e d   o n   b e f o r e   t h e y   w e r e   s e p a r a t e d .   I f   y o u   c h e c k   t h e  
         / /   c u r r e n t   s t a t e   o f   t h e i r   n e i g h b o r s   o n   t h o s e   s i d e s ,   t h e y   s h o u l d   o f   c o u r s e  
         / /   b e   N O N E .  
         p r i v a t e   v o i d   O n N e i g h b o r R e m o v e ( C u b e   c u b e 1 ,   C u b e . S i d e   s i d e 1 ,   C u b e   c u b e 2 ,   C u b e . S i d e   s i d e 2 )     {  
             L o g . D e b u g ( " N e i g h b o r   r e m o v e :   { 0 } . { 1 }   < - >   { 2 } . { 3 } " ,   c u b e 1 . U n i q u e I d ,   s i d e 1 ,   c u b e 2 . U n i q u e I d ,   s i d e 2 ) ;  
  
             C u b e W r a p p e r   w r a p p e r   =   ( C u b e W r a p p e r ) c u b e 1 . u s e r D a t a ;  
             i f   ( w r a p p e r   ! =   n u l l )   {  
                 w r a p p e r . m S c a l e   =   1 ;  
                 w r a p p e r . m R o t a t i o n   =   0 ;  
                 w r a p p e r . m N e e d D r a w   =   t r u e ;  
             }  
  
             w r a p p e r   =   ( C u b e W r a p p e r ) c u b e 2 . u s e r D a t a ;  
             i f   ( w r a p p e r   ! =   n u l l )   {  
                 w r a p p e r . m S c a l e   =   1 ;  
                 w r a p p e r . m R o t a t i o n   =   0 ;  
                 w r a p p e r . m N e e d D r a w   =   t r u e ;  
             }  
         }  
  
         / /   D e f e r   a l l   p e r - f r a m e   l o g i c   t o   e a c h   c u b e ' s   w r a p p e r .  
         p u b l i c   o v e r r i d e   v o i d   T i c k ( )   {  
             f o r e a c h   ( C u b e W r a p p e r   w r a p p e r   i n   m W r a p p e r s )   {  
                 w r a p p e r . T i c k ( ) ;  
             }  
         }  
  
         / /   I m a g e S e t   i s   a n   e n u m e r a t i o n   o f   y o u r   a p p ' s   i m a g e s .   I t   i s   p o p u l a t e d   b a s e d  
         / /   o n   y o u r   a p p ' s   s i f t b u n d l e   a n d   i n d e x .   Y o u   r a r e l y   h a v e   t o   i n t e r a c t   w i t h   i t  
         / /   d i r e c t l y ,   s i n c e   y o u   c a n   r e f e r   t o   i m a g e s   b y   n a m e .  
         / /  
         / /   I n   t h i s   m e t h o d ,   w e   s c a n   t h e   i m a g e   s e t   t o   b u i l d   a n   a r r a y   w i t h   t h e   n a m e s  
         / /   o f   a l l   t h e   i m a g e s .  
         p r i v a t e   S t r i n g [ ]   L o a d I m a g e I n d e x ( )   {  
             I m a g e S e t   i m a g e S e t   =   t h i s . I m a g e s ;  
             A r r a y L i s t   n a m e L i s t   =   n e w   A r r a y L i s t ( ) ;  
             f o r e a c h   ( I m a g e I n f o   i m a g e   i n   i m a g e S e t )   {  
                 n a m e L i s t . A d d ( i m a g e . n a m e ) ;  
             }  
             S t r i n g [ ]   r v   =   n e w   S t r i n g [ n a m e L i s t . C o u n t ] ;  
             f o r   ( i n t   i = 0 ;   i < n a m e L i s t . C o u n t ;   i + + )   {  
                 r v [ i ]   =   ( s t r i n g ) n a m e L i s t [ i ] ;  
             }  
             r e t u r n   r v ;  
         }  
  
     }  
  
     / /   - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
  
     / /   # #   W r a p p e r   # #  
     / /   " W r a p p e r "   i s   n o t   a   s p e c i f i c   A P I ,   b u t   a   p a t t e r n   t h a t   i s   u s e d   i n   m a n y   S i f t e o  
     / /   a p p s .   A   w r a p p e r   i s   a n   o b j e c t   t h a t   b u n d l e s   a   C u b e   o b j e c t   w i t h   g a m e - s p e c i f i c  
     / /   d a t a   a n d   b e h a v i o r s .  
     p u b l i c   c l a s s   C u b e W r a p p e r   {  
  
         p u b l i c   T r u m p W a v e A p p   m A p p ;  
         p u b l i c   C u b e   m C u b e ;  
         p u b l i c   i n t   m I n d e x ;  
         p u b l i c   i n t   m X O f f s e t   =   0 ;  
         p u b l i c   i n t   m Y O f f s e t   =   0 ;  
         p u b l i c   i n t   m S c a l e   =   1 ;  
         p u b l i c   i n t   m R o t a t i o n   =   0 ;  
  
         / /   T h i s   f l a g   t e l l s   t h e   w r a p p e r   t o   r e d r a w   t h e   c u r r e n t   i m a g e   o n   t h e   c u b e .   ( S e e   T i c k ,   b e l o w ) .  
         p u b l i c   b o o l   m N e e d D r a w   =   f a l s e ;  
  
         p u b l i c   C u b e W r a p p e r ( T r u m p W a v e A p p   a p p ,   C u b e   c u b e )   {  
             m A p p   =   a p p ;  
             m C u b e   =   c u b e ;  
             m C u b e . u s e r D a t a   =   t h i s ;  
             m I n d e x   =   0 ;  
  
             / /   H e r e   w e   a t t a c h   m o r e   e v e n t   h a n d l e r s   f o r   b u t t o n   a n d   a c c e l e r o m e t e r   a c t i o n s .  
             m C u b e . B u t t o n E v e n t   + =   O n B u t t o n ;  
             m C u b e . T i l t E v e n t   + =   O n T i l t ;  
             m C u b e . S h a k e S t a r t e d E v e n t   + =   O n S h a k e S t a r t e d ;  
             m C u b e . S h a k e S t o p p e d E v e n t   + =   O n S h a k e S t o p p e d ;  
             m C u b e . F l i p E v e n t   + =   O n F l i p ;  
         }  
  
         / /   # #   B u t t o n   # #  
         / /   T h i s   i s   a   h a n d l e r   f o r   t h e   B u t t o n   e v e n t .   I t   i s   t r i g g e r e d   w h e n   a   c u b e ' s  
         / /   f a c e   b u t t o n   i s   e i t h e r   p r e s s e d   o r   r e l e a s e d .   T h e   ` p r e s s e d `   a r g u m e n t  
         / /   i s   t r u e   w h e n   y o u   p r e s s   d o w n   a n d   f a l s e   w h e n   y o u   r e l e a s e .  
         p r i v a t e   v o i d   O n B u t t o n ( C u b e   c u b e ,   b o o l   p r e s s e d )   {  
             i f   ( p r e s s e d )   {  
                 L o g . D e b u g ( " B u t t o n   p r e s s e d " ) ;  
             }   e l s e   {  
                 L o g . D e b u g ( " B u t t o n   r e l e a s e d " ) ;  
  
                 / /   A d v a n c e   t h e   i m a g e   i n d e x   s o   t h a t   t h e   n e x t   i m a g e   i s   d r a w n   o n   t h i s  
                 / /   c u b e .  
                 t h i s . m I n d e x   + =   1 ;  
                 i f   ( m I n d e x   > =   m A p p . m I m a g e N a m e s . L e n g t h )   {  
                     m I n d e x   =   0 ;  
                 }  
                 m R o t a t i o n   =   0 ;  
                 m S c a l e   =   1 ;  
                 m N e e d D r a w   =   t r u e ;  
  
             }  
         }  
  
         / /   # #   T i l t   # #  
         / /   T h i s   i s   a   h a n d l e r   f o r   t h e   T i l t   e v e n t .   I t   i s   t r i g g e r e d   w h e n   a   c u b e   i s  
         / /   t i l t e d   p a s t   a   c e r t a i n   t h r e s h o l d .   T h e   x ,   y ,   a n d   z   a r g u m e n t s   a r e   f i l t e r e d  
         / /   v a l u e s   f o r   t h e   c u b e ' s   t h r e e - a x i s   a c c e l e r o m t e r .   A   t i l t   e v e n t   i s   o n l y  
         / /   t r i g g e r e d   w h e n   t h e   f i l t e r e d   v a l u e   c h a n g e s ,   i . e . ,   w h e n   t h e   a c c e l e r o m e t e r  
         / /   c r o s s e s   c e r t a i n   t h r e s h o l d s .  
         p r i v a t e   v o i d   O n T i l t ( C u b e   c u b e ,   i n t   t i l t X ,   i n t   t i l t Y ,   i n t   t i l t Z )   {  
             L o g . D e b u g ( " T i l t :   { 0 }   { 1 }   { 2 } " ,   t i l t X ,   t i l t Y ,   t i l t Z ) ;  
  
             / /   I f   t h e   X   a x i s   t i l t   r e a d s   0 ,   t h e   c u b e   i s   t i l t i n g   t o   t h e   l e f t .   < b r / >  
             / /   I f   i t   r e a d s   1 ,   t h e   c u b e   i s   c e n t e r e d .   < b r / >  
             / /   I f   i t   r e a d s   2 ,   t h e   c u b e   i s   t i l t i n g   t o   t h e   r i g h t .  
             i f   ( t i l t X   = =   0 )   {  
                 m X O f f s e t   =   - 8 ;  
             }   e l s e   i f   ( t i l t X   = =   1 )   {  
                 m X O f f s e t   =   0 ;  
             }   e l s e   i f   ( t i l t X   = =   2 )   {  
                 m X O f f s e t   =   8 ;  
             }  
  
             / /   I f   t h e   Y   a x i s   t i l t   r e a d s   0 ,   t h e   c u b e   i s   t i l t i n g   d o w n .   < b r / >  
             / /   I f   i t   r e a d s   1 ,   t h e   c u b e   i s   c e n t e r e d .   < b r / >  
             / /   I f   i t   r e a d s   2 ,   t h e   c u b e   i s   t i l t i n g   u p .  
             i f   ( t i l t Y   = =   0 )   {  
                 m Y O f f s e t   =   8 ;  
             }   e l s e   i f   ( t i l t Y   = =   1 )   {  
                 m Y O f f s e t   =   0 ;  
             }   e l s e   i f   ( t i l t Y   = =   2 )   {  
                 m Y O f f s e t   =   - 8 ;  
             }  
  
             / /   I f   t h e   Z   a x i s   t i l t   r e a d s   2 ,   t h e   c u b e   i s   f a c e   u p .   < b r / >  
             / /   I f   i t   r e a d s   1 ,   t h e   c u b e   i s   s t a n d i n g   o n   a   s i d e .   < b r / >  
             / /   I f   i t   r e a d s   0 ,   t h e   c u b e   i s   f a c e   d o w n .  
             i f   ( t i l t Z   = =   1 )   {  
                 m X O f f s e t   * =   2 ;  
                 m Y O f f s e t   * =   2 ;  
             }  
  
             m N e e d D r a w   =   t r u e ;  
         }  
  
         / /   # #   S h a k e   S t a r t e d   # #  
         / /   T h i s   i s   a   h a n d l e r   f o r   t h e   S h a k e S t a r t e d   e v e n t .   I t   i s   t r i g g e r e d   w h e n   t h e  
         / /   p l a y e r   s t a r t s   s h a k i n g   a   c u b e .   W h e n   t h e   p l a y e r   s t o p s   s h a k i n g ,   a  
         / /   c o r r e s p o n d i n g   S h a k e S t o p p e d   e v e n t   w i l l   b e   f i r e d   ( s e e   b e l o w ) .  
         / /  
         / /   N o t e :   w h i l e   a   c u b e   i s   s h a k i n g ,   i t   w i l l   s t i l l   f i r e   t i l t   a n d   f l i p   e v e n t s  
         / /   a s   i t s   i n t e r n a l   a c c e l e r o m e t e r   g o e s   a r o u n d   a n d   a r o u n d .   I f   y o u r   g a m e   w a n t s  
         / /   t o   t r e a t   s h a k i n g   s e p a r a t e l y   f r o m   t i l t i n g   o r   f l i p p i n g ,   y o u   n e e d   t o   a d d  
         / /   l o g i c   t o   f i l t e r   e v e n t s   a p p r o p r i a t e l y .  
         p r i v a t e   v o i d   O n S h a k e S t a r t e d ( C u b e   c u b e )   {  
             L o g . D e b u g ( " S h a k e   s t a r t " ) ;  
         }  
  
         / /   # #   S h a k e   S t o p p e d   # #  
         / /   T h i s   i s   a   h a n d l e r   f o r   t h e   S h a k e S t a r t e d   e v e n t .   I t   i s   t r i g g e r e d   w h e n   t h e  
         / /   p l a y e r   s t o p s   s h a k i n g   a   c u b e .   T h e   ` d u r a t i o n `   a r g u m e n t   t e l l s   y o u  
         / /   h o w   l o n g   ( i n   m i l l i s e c o n d s )   t h e   c u b e   w a s   s h a k e n .  
         p r i v a t e   v o i d   O n S h a k e S t o p p e d ( C u b e   c u b e ,   i n t   d u r a t i o n )   {  
             L o g . D e b u g ( " S h a k e   s t o p :   { 0 } " ,   d u r a t i o n ) ;  
             m R o t a t i o n   =   0 ;  
             m N e e d D r a w   =   t r u e ;  
         }  
  
         / /   # #   F l i p   # #  
         / /   T h i s   i s   a   h a n d l e r   f o r   t h e   F l i p   e v e n t .   I t   i s   t r i g g e r e d   w h e n   t h e   p l a y e r  
         / /   t u r n s   a   c u b e   f a c e   d o w n   o r   f a c e   u p .   T h e   ` n e w O r i e n t a t i o n I s U p `   a r g u m e n t  
         / /   t e l l s   y o u   w h i c h   w a y   t h e   c u b e   i s   n o w   f a c i n g .  
         / /  
         / /   N o t e   t h a t   w h e n   a   F l i p   e v e n t   i s   t r i g g e r e d ,   a   T i l t   e v e n t   i s   a l s o  
         / /   t r i g g e r e d .  
         p r i v a t e   v o i d   O n F l i p ( C u b e   c u b e ,   b o o l   n e w O r i e n t a t i o n I s U p )   {  
             i f   ( n e w O r i e n t a t i o n I s U p )   {  
                 L o g . D e b u g ( " F l i p   f a c e   u p " ) ;  
                 m S c a l e   =   1 ;  
                 m N e e d D r a w   =   t r u e ;  
             }   e l s e   {  
                 L o g . D e b u g ( " F l i p   f a c e   d o w n " ) ;  
                 m S c a l e   =   2 ;  
                 m N e e d D r a w   =   t r u e ;  
             }  
         }  
  
         / /   # #   C u b e . I m a g e   # #  
         / /   T h i s   m e t h o d   d r a w s   t h e   c u r r e n t   i m a g e   t o   t h e   c u b e ' s   d i s p l a y .   T h e  
         / /   C u b e . I m a g e   m e t h o d   h a s   a   l o t   o f   a r g u m e n t s ,   b u t   m a n y   o f   t h e m   a r e   o p t i o n a l  
         / /   a n d   h a v e   r e a s o n a b l e   d e f a u l t   v a l u e s .  
         p u b l i c   v o i d   D r a w S l i d e ( )   {  
  
             / /   H e r e   w e   s p e c i f y   t h e   n a m e   o f   t h e   i m a g e   t o   d r a w ,   i n   t h i s   c a s e   b y   p u l l i n g  
             / /   i t   f r o m   t h e   a r r a y   o f   n a m e s   w e   r e a d   o u t   o f   t h e   i m a g e   s e t   ( s e e  
             / /   L o a d I m a g e I n d e x ,   a b o v e ) .  
             / /  
             / /   W h e n   s p e c i f y i n g   t h e   i m a g e   n a m e ,   l e a v e   o f f   a n y   f i l e   t y p e   e x t e n s i o n s  
             / /   ( p n g ,   g i f ,   e t c ) .   R e f e r   t o   t h e   i n d e x   f i l e   t h a t   I m a g e H e l p e r   g e n e r a t e s  
             / /   d u r i n g   a s s e t   c o n v e r s i o n .  
             / /  
             / /   I f   y o u   s p e c i f y   a n   i m a g e   n a m e   t h a t   i s   n o t   i n   t h e   i n d e x ,   t h e   I m a g e   c a l l  
             / /   w i l l   b e   i g n o r e d .  
             S t r i n g   i m a g e N a m e   =   t h i s . m A p p . m I m a g e N a m e s [ t h i s . m I n d e x ] ;  
  
             / /   Y o u   c a n   s p e c i f y   t h e   t o p / l e f t   p o i n t   o n   t h e   s c r e e n   t o   s t a r t   d r a w i n g   a t .  
             i n t   s c r e e n X   =   m X O f f s e t ;  
             i n t   s c r e e n Y   =   m Y O f f s e t ;  
  
             / /   Y o u   c a n   d r a w   a   p o r t i o n   o f   a n   i m a g e   b y   s p e c i f y i n g   c o o r d i n a t e s   t o   s t a r t  
             / /   r e a d i n g   f r o m   ( t o p / l e f t ) .   I n   t h i s   c a s e ,   w e ' r e   j u s t   g o i n g   t o   d r a w   t h e  
             / /   w h o l e   i m a g e   e v e r y   t i m e .  
             i n t   i m a g e X   =   0 ;  
             i n t   i m a g e Y   =   0 ;  
  
             / /   Y o u   s h o u l d   a l w a y s   s p e c i f y   t h e   w i d t h   a n d   h e i g h t   o f   t h e   i m a g e   t o   b e  
             / /   d r a w n .   I f   y o u   s p e c i f y   v a l u e s   t h a t   a r e   l e s s   t h a n   t h e   s i z e   o f   t h e   i m a g e ,  
             / /   o n l y   t h e   p o r t i o n   y o u   s p e c i f y   w i l l   b e   d r a w n .   I f   y o u   s p e c i f y   v a l u e s  
             / /   l a r g e r   t h a n   t h e   i m a g e ,   t h e   b e h a v i o r   i s   u n d e f i n e d   ( s o   d o n ' t   d o   t h a t ) .  
             / /  
             / /   I n   t h i s   e x a m p l e ,   w e   a s s u m e   t h a t   t h e   i m a g e   i s   1 2 8 x 1 2 8 ,   b i g   e n o u g h   t o  
             / /   c o v e r   t h e   f u l l   s i z e   o f   t h e   d i s p l a y .   I f   t h e   i m a g e   r u n s   o f f   t h e   s i d e s   o f  
             / /   t h e   d i s p l a y   ( b e c a u s e   o f   o f f s e t s   d u e   t o   t i l t i n g ;   s e e   O n T i l t ,   a b o v e ) ,   i t  
             / /   w i l l   b e   c l i p p e d .  
             i n t   w i d t h   =   1 2 8 ;  
             i n t   h e i g h t   =   1 2 8 ;  
  
             / /   Y o u   c a n   u p s c a l e   a n   i m a g e   b y   i n t e g e r   m u l t i p l e s .   A   s c a l e d   i m a g e   s t i l l  
             / /   s t a r t s   d r a w i n g   a t   t h e   s p e c i f i e d   t o p / l e f t   p o i n t ,   b u t   t h e   a r e a   o f   t h e  
             / /   d i s p l a y   i t   c o v e r s   ( w i d t h / h e i g h t )   w i l l   b e   m u l t i p l e d   b y   t h e   s c a l e .  
             / /  
             / /   T h e   d e f a u l t   v a l u e   i s   1   ( 1 : 1   s c a l e ) .  
             i n t   s c a l e   =   m S c a l e ;  
  
             / /   Y o u   c a n   r o t a t e   a n   i m a g e   b y   q u a r t e r s .   T h e   r o t a t i o n   v a l u e   i s   a n   i n t e g e r  
             / /   r e p r e s e n t i n g   c o u n t e r c l o c k w i s e   r o t a t i o n .  
             / /  
             / /   *   0   =   n o   r o t a t i o n  
             / /   *   1   =   9 0   d e g r e e s   c o u n t e r c l o c k w i s e  
             / /   *   2   =   1 8 0   d e g r e e s  
             / /   *   3   =   9 0   d e g r e e s   c l o c k w i s e  
             / /  
             / /   A   r o t a t e d   i m a g e   s t i l l   s t a r t s   d r a w i n g   a t   t h e   s p e c i f i e d   t o p / l e f t   p o i n t ;  
             / /   t h e   p i x e l s   a r e   j u s t   d r a w n   i n   r o t a t e d   o r d e r .  
             / /  
             / /   T h e   d e f a u l t   v a l u e   i s   0   ( n o   r o t a t i o n ) .  
             i n t   r o t a t i o n   =   m R o t a t i o n ;  
  
             / /   C l e a r   o f f   w h a t e v e r   w a s   p r e v i o u s l y   o n   t h e   d i s p l a y   b e f o r e   d r a w i n g   t h e   n e w   i m a g e .  
             m C u b e . F i l l S c r e e n ( C o l o r . B l a c k ) ;  
  
             m C u b e . I m a g e ( i m a g e N a m e ,   s c r e e n X ,   s c r e e n Y ,   i m a g e X ,   i m a g e Y ,   w i d t h ,   h e i g h t ,   s c a l e ,   r o t a t i o n ) ;  
  
             / /   R e m e m b e r :   a l w a y s   c a l l   P a i n t   i f   y o u   a c t u a l l y   w a n t   t o   s e e   a n y t h i n g   o n   t h e   c u b e ' s   d i s p l a y .  
             m C u b e . P a i n t ( ) ;  
         }  
  
         / /   T h i s   m e t h o d   i s   c a l l e d   e v e r y   f r a m e   b y   t h e   T i c k   i n   T r u m p W a v e A p p   ( s e e   a b o v e . )  
         p u b l i c   v o i d   T i c k ( )   {  
  
             / /   Y o u   c a n   c h e c k   w h e t h e r   a   c u b e   i s   b e i n g   s h a k e n   a t   t h i s   m o m e n t   b y   l o o k i n g  
             / /   a t   t h e   I s S h a k i n g   f l a g .  
             i f   ( m C u b e . I s S h a k i n g )   {  
                 m R o t a t i o n   =   m A p p . m R a n d o m . N e x t ( 4 ) ;  
                 m N e e d D r a w   =   t r u e ;  
             }  
  
             / /   I f   a n y o n e   h a s   r a i s e d   t h e   m N e e d D r a w   f l a g ,   r e d r a w   t h e   i m a g e   o n   t h e   c u b e .  
             i f   ( m N e e d D r a w )   {  
                 m N e e d D r a w   =   f a l s e ;  
                 D r a w S l i d e ( ) ;  
             }  
         }  
  
     }  
 }  
  
 / /   - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 / /  
 / /   T r u m p W a v e A p p . c s  
 / /  
 / /   C o p y r i g h t   & c o p y ;   2 0 1 1   S i f t e o   I n c .  
 / /  
 / /   T h i s   p r o g r a m   i s   " S a m p l e   C o d e "   a s   d e f i n e d   i n   t h e   S i f t e o  
 / /   S o f t w a r e   D e v e l o p m e n t   K i t   L i c e n s e   A g r e e m e n t .   B y   a d a p t i n g  
 / /   o r   l i n k i n g   t o   t h i s   p r o g r a m ,   y o u   a g r e e   t o   t h e   t e r m s   o f   t h e  
 / /   L i c e n s e   A g r e e m e n t .  
 / /  
 / /   I f   t h i s   p r o g r a m   w a s   d i s t r i b u t e d   w i t h o u t   t h e   f u l l   L i c e n s e  
 / /   A g r e e m e n t ,   a   c o p y   c a n   b e   o b t a i n e d   b y   c o n t a c t i n g  
 / /   s u p p o r t @ s i f t e o . c o m .  
 / /  
  
 